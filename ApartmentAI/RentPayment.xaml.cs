using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ApartmentAI 
{
    public partial class RentPaymentWindow : Window
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ApartmentDBConnection"]?.ConnectionString;

        public RentPaymentWindow()
        {
            InitializeComponent();
            Loaded += RentPaymentWindow_Loaded; 
        }

        private void RentPaymentWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dtpPaymentDate.SelectedDate = DateTime.Now; 
            LoadTenants();
            LoadPayments();
        }

        void LoadPayments()
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                string query = @"
                    SELECT 
                        RP.Id, 
                        T.FullName, 
                        A.ApartmentNo, 
                        RP.Amount, 
                        RP.PaymentDate, 
                        RP.IsPaid 
                    FROM RentPayments RP 
                    INNER JOIN Tenants T ON RP.TenantId = T.Id 
                    INNER JOIN Apartments A ON T.ApartmentId = A.Id 
                    ORDER BY RP.PaymentDate DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPayments.ItemsSource = dt.DefaultView; 
            }
        }

       
        void LoadTenants()
        {
            if (string.IsNullOrEmpty(connectionString)) return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                
                string query = @"
                    SELECT 
                        T.Id, 
                        T.FullName + ' - Daire: ' + A.ApartmentNo AS DisplayName 
                    FROM Tenants T 
                    INNER JOIN Apartments A ON T.ApartmentId = A.Id";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbTenants.ItemsSource = dt.DefaultView;
            }
        }

   
        private void btnAddPayment_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtAmount.Text))
            {
                MessageBox.Show("\r\nPlease enter the amount.");
                return;
            }

            if (cmbTenants.SelectedValue == null)
            {
                MessageBox.Show("\r\nPlease choose a tenant.");
                return;
            }

            try
            {
                decimal amount = Convert.ToDecimal(txtAmount.Text);
                int tenantId = Convert.ToInt32(cmbTenants.SelectedValue);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO RentPayments (TenantId, Amount, PaymentDate, IsPaid) 
                        VALUES (@TenantId, @Amount, @PaymentDate, @IsPaid)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@TenantId", tenantId);
                    cmd.Parameters.AddWithValue("@Amount", amount);
                    cmd.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.SelectedDate ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@IsPaid", chkIsPaid.IsChecked ?? false);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                MessageBox.Show("Payment added successfully.");
                LoadPayments();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("\r\nError occurred: " + ex.Message);
            }
        }

        void ClearForm()
        {
            txtAmount.Clear();
            chkIsPaid.IsChecked = false;
            dtpPaymentDate.SelectedDate = DateTime.Now;
            cmbTenants.SelectedIndex = -1;
        }

        
        private void btnMarkAsPaid_Click(object sender, RoutedEventArgs e)
        {
            if (dgvPayments.SelectedItem == null)
            {
                MessageBox.Show("Please select a payment method from the list.");
                return;
            }

            
            DataRowView row = (DataRowView)dgvPayments.SelectedItem;

            bool isPaid = (bool)row["IsPaid"];
            if (isPaid)
            {
                MessageBox.Show("\r\nThis payment has already been made.");
                return;
            }

            int paymentId = (int)row["Id"];

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE RentPayments SET IsPaid = 1 WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@id", paymentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("\r\nPayment has been updated to 'Paid'.");
            LoadPayments();
        }

    }
}