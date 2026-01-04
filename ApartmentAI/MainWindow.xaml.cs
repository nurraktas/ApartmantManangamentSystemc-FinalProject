using ApartmentAI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ApartmentAI
{
    public partial class MainWindow : Window
    {
        private int selectedApartmentId = 0;

        string connectionString = "Server=.\\SQLEXPRESS03;Database=ApartmentDB;Trusted_Connection=True;";

        public MainWindow()
        {
            InitializeComponent();
            LoadApartments();
        }
        private void SelectApartmentById(int apartmentId)
        {
            foreach (var item in dgApartments.Items)
            {
                if (item is DataRowView row)
                {
                    if (Convert.ToInt32(row["Id"]) == apartmentId)
                    {
                        dgApartments.SelectedItem = row;
                        dgApartments.ScrollIntoView(row);
                        break;
                    }
                }
            }
        }
        private void BtnPayment_Click(object sender, RoutedEventArgs e)
        {
            RentPaymentWindow paymentWindow = new RentPaymentWindow();
            paymentWindow.ShowDialog();
        }


        private void BtnAddTenant_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TenantWindow tenantWindow = new TenantWindow(selectedApartmentId);

                bool? result = tenantWindow.ShowDialog();

                if (result == true)
                {
                    
                    LoadApartments();
                    SelectApartmentById(selectedApartmentId);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while opening tenant screen: " + ex.Message);
            }
        }

        private void LoadApartments()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM Apartments";
                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgApartments.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data loading error: " + ex.Message);
            }
        }


        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"INSERT INTO Apartments 
                                    (ApartmentNo, Floor, IsOccupied) 
                                    VALUES (@AptNo, @Floor, @IsOccupied)";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@AptNo", txtAptNo.Text);
                    cmd.Parameters.AddWithValue("@Floor", int.Parse(txtFloor.Text));
                    cmd.Parameters.AddWithValue("@IsOccupied", chkOccupied.IsChecked ?? false);
                   
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Apartment added ✔");
                    LoadApartments();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("\r\nAddition error: " + ex.Message);
            }
        }

       
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgApartments.SelectedItem == null) return;

            DataRowView row = (DataRowView)dgApartments.SelectedItem;
            int id = Convert.ToInt32(row["Id"]);

            if (MessageBox.Show("Do you want to delete?", "Approval",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string query = "DELETE FROM Apartments WHERE Id=@Id";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();

                        LoadApartments();
                        ClearInputs();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("\r\ndelete error " + ex.Message);
                }
            }
        }

  
        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (dgApartments.SelectedItem == null) return;

            DataRowView row = (DataRowView)dgApartments.SelectedItem;
            int id = Convert.ToInt32(row["Id"]);

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = @"UPDATE Apartments 
                                    SET ApartmentNo=@AptNo,
                                        Floor=@Floor,
                                        IsOccupied=@IsOccupied
                                        
                                        WHERE Id=@Id";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Parameters.AddWithValue("@AptNo", txtAptNo.Text);
                    cmd.Parameters.AddWithValue("@Floor", int.Parse(txtFloor.Text));
                    cmd.Parameters.AddWithValue("@IsOccupied", chkOccupied.IsChecked ?? false);
                   

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Update ✔");
                    LoadApartments();
                    ClearInputs();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("update error: " + ex.Message);
            }
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearInputs();
        }
        private void DgApartments_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgApartments.SelectedItem == null) return;

            DataRowView row = dgApartments.SelectedItem as DataRowView;
            if (row == null) return;

            selectedApartmentId = Convert.ToInt32(row["Id"]);

            txtAptNo.Text = row["ApartmentNo"].ToString();
            txtFloor.Text = row["Floor"].ToString();
            chkOccupied.IsChecked = Convert.ToBoolean(row["IsOccupied"]);

            txtTenantName.Clear();
            txtPhone.Clear();

            int tenantId = 0;
            bool hasPaid = false;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                
                string tenantQuery = @"
            SELECT TOP 1 Id, FullName, Phone 
            FROM Tenants 
            WHERE ApartmentId = @ApartmentId";

                SqlCommand tenantCmd = new SqlCommand(tenantQuery, con);
                tenantCmd.Parameters.AddWithValue("@ApartmentId", selectedApartmentId);

                SqlDataReader reader = tenantCmd.ExecuteReader();

                if (reader.Read())
                {
                    tenantId = Convert.ToInt32(reader["Id"]);
                    txtTenantName.Text = reader["FullName"].ToString();
                    txtPhone.Text = reader["Phone"].ToString();
                }

                reader.Close();

               
                if (tenantId > 0)
                {
                    string paymentQuery = @"
                SELECT COUNT(*) 
                FROM RentPayments 
                WHERE TenantId = @TenantId AND IsPaid = 1";

                    SqlCommand paymentCmd = new SqlCommand(paymentQuery, con);
                    paymentCmd.Parameters.AddWithValue("@TenantId", tenantId);

                    hasPaid = Convert.ToInt32(paymentCmd.ExecuteScalar()) > 0;
                }
            }

            if (chkOccupied.IsChecked == false)
            {
                
                btnAddTenant.IsEnabled = true;
                btnPayment.IsEnabled = false;
            }
            else
            {
                
                btnAddTenant.IsEnabled = false;

                if (hasPaid)
                {
                    btnPayment.IsEnabled = false;
                    btnPayment.ToolTip = "This tenant has already paid.";
                }
                else
                {
                    btnPayment.IsEnabled = true;
                    btnPayment.ToolTip = null;
                }
            }
        }

        private void btnVacate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedApartmentId == 0)
            {
                MessageBox.Show("Please select an apartment.");
                return;
            }

            if (chkOccupied.IsChecked == false)
            {
                MessageBox.Show("This apartment is already vacant.");
                return;
            }

            if (MessageBox.Show(
                "Are you sure you want to vacate this apartment?",
                "Approval",
                MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                return;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    int tenantId = 0;

                    SqlCommand cmdGetTenant = new SqlCommand(
                        "SELECT Id FROM Tenants WHERE ApartmentId = @aptId",
                        con, transaction);
                    cmdGetTenant.Parameters.AddWithValue("@aptId", selectedApartmentId);

                    object result = cmdGetTenant.ExecuteScalar();
                    if (result != null)
                        tenantId = Convert.ToInt32(result);

                    
                    if (tenantId > 0)
                    {
                        SqlCommand cmdDeletePayments = new SqlCommand(
                            "DELETE FROM RentPayments WHERE TenantId = @tId",
                            con, transaction);
                        cmdDeletePayments.Parameters.AddWithValue("@tId", tenantId);
                        cmdDeletePayments.ExecuteNonQuery();
                    }

                    
                    SqlCommand cmdDeleteTenant = new SqlCommand(
                        "DELETE FROM Tenants WHERE ApartmentId = @aptId",
                        con, transaction);
                    cmdDeleteTenant.Parameters.AddWithValue("@aptId", selectedApartmentId);
                    cmdDeleteTenant.ExecuteNonQuery();

                    
                    SqlCommand cmdUpdateApartment = new SqlCommand(
                        "UPDATE Apartments SET IsOccupied = 0 WHERE Id = @aptId",
                        con, transaction);
                    cmdUpdateApartment.Parameters.AddWithValue("@aptId", selectedApartmentId);
                    cmdUpdateApartment.ExecuteNonQuery();

                    transaction.Commit();

                    MessageBox.Show("The apartment has been successfully vacated.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            dgApartments.ItemsSource = null;
            
            LoadApartments();
            ClearInputs();
        }


        private void ClearInputs()
        {
            txtAptNo.Clear();
            txtFloor.Clear();
            txtTenantName.Clear();
            txtPhone.Clear();

            chkOccupied.IsChecked = false;

            dgApartments.SelectedItem = null;
            selectedApartmentId = 0;   

            btnAddTenant.IsEnabled = false;
            btnPayment.IsEnabled = false;
        }

        private void txtTenantName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtPhone_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        

    }
}
