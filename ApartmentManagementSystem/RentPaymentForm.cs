using ApartmentManagementSystem.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApartmentManagementSystem
{
    public partial class RentPaymentForm : Form
    {
        public RentPaymentForm()
        {
            InitializeComponent();
        }

        private void RentPaymentForm_Load(object sender, EventArgs e)
        {
            
            LoadTenants();
            LoadPayments();
        }
        void LoadPayments()
        {
            string cs = ConfigurationManager
                .ConnectionStrings["ApartmentDbConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                RP.Id,
                T.FullName,
                A.ApartmentNo,
                RP.Amount,
                RP.PaymentDate,
                RP.IsPaid
              FROM RentPayments RP
              INNER JOIN Tenants T ON RP.TenantId = T.Id
              INNER JOIN Apartments A ON T.ApartmentId = A.Id
              ORDER BY RP.PaymentDate DESC",
                    con
                );

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvPayments.DataSource = dt;
            }

            dgvPayments.Columns["Id"].Visible = false;
        }

        void LoadTenants()
        {
            string cs = ConfigurationManager
       .ConnectionStrings["ApartmentDbConnection"]
       .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    @"SELECT 
                T.Id, 
                T.FullName + ' - Apt ' + A.ApartmentNo AS DisplayName
              FROM Tenants T
              INNER JOIN Apartments A ON T.ApartmentId = A.Id",
                    con
                );

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbTenants.DataSource = dt;
                cmbTenants.DisplayMember = "DisplayName";
                cmbTenants.ValueMember = "Id";
            }

        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (txtAmount.Text == "")
            {
                MessageBox.Show("Please enter amount.");
                return;
            }

            decimal amount = Convert.ToDecimal(txtAmount.Text);
            int tenantId = Convert.ToInt32(cmbTenants.SelectedValue);

            string cs = ConfigurationManager
                .ConnectionStrings["ApartmentDbConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO RentPayments 
              (TenantId, Amount, PaymentDate, IsPaid)
              VALUES (@TenantId, @Amount, @PaymentDate, @IsPaid)",
                    con
                );

                cmd.Parameters.AddWithValue("@TenantId", tenantId);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@PaymentDate", dtpPaymentDate.Value.Date);
                cmd.Parameters.AddWithValue("@IsPaid", chkIsPaid.Checked);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Rent payment added successfully.");

            LoadPayments();   
            ClearForm();
        }
        void ClearForm()
        {
            txtAmount.Clear();
            chkIsPaid.Checked = false;
            dtpPaymentDate.Value = DateTime.Now;
        }




        private void btnMarkAsPaid_Click(object sender, EventArgs e)
        {
            if (dgvPayments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a payment.");
                return;
            }

            bool isPaid = Convert.ToBoolean(
                dgvPayments.SelectedRows[0].Cells["IsPaid"].Value
            );

            if (isPaid)
            {
                MessageBox.Show("This payment is already marked as paid.");
                return;
            }

            int paymentId = Convert.ToInt32(
                dgvPayments.SelectedRows[0].Cells["Id"].Value
            );

            string cs = ConfigurationManager
                .ConnectionStrings["ApartmentDbConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE RentPayments SET IsPaid = 1 WHERE Id = @id",
                    con
                );

                cmd.Parameters.AddWithValue("@id", paymentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadPayments();

            MessageBox.Show("Payment marked as paid.");
        }

        private void dgvPayments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPayments.Columns[e.ColumnIndex].Name == "IsPaid")
            {
                bool isPaid = false;

                var value = dgvPayments.Rows[e.RowIndex].Cells["IsPaid"].Value;

                if (value != DBNull.Value && value != null)
                {
                    isPaid = Convert.ToBoolean(value);
                }

                dgvPayments.Rows[e.RowIndex].DefaultCellStyle.BackColor =
                    isPaid ? Color.LightGreen : Color.LightCoral;
            }

        }

        private void cmbTenants_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
