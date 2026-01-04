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
    public partial class TenantForm : Form
    {
        public TenantForm()
        {
            InitializeComponent();
        }

        private void TenantForm_Load(object sender, EventArgs e)
        {
            LoadTenants();
            LoadApartments();

        }

        void LoadApartments()
        {
            string cs = ConfigurationManager.ConnectionStrings["ApartmentDbConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, ApartmentNo FROM Apartments WHERE IsOccupied = 0", con
                );

                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbApartments.DataSource = dt;
                cmbApartments.DisplayMember = "ApartmentNo"; 
                cmbApartments.ValueMember = "Id";          
                cmbApartments.SelectedIndex = -1;           
            }
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
                T.FullName,
                T.Phone,
                A.ApartmentNo
              FROM Tenants T
              INNER JOIN Apartments A ON T.ApartmentId = A.Id",
                    con
                );

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvTenants.DataSource = dt;
            }
            dgvTenants.Columns["Id"].Visible = false;
        }

        private void btnAddTenant_Click(object sender, EventArgs e)
        {
            if (TxtFullName.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            int apartmentId = Convert.ToInt32(cmbApartments.SelectedValue);

            string cs = ConfigurationManager.ConnectionStrings["ApartmentDbConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Tenants (FullName, Phone, ApartmentId) VALUES (@FullName, @Phone, @ApartmentId)",
                    con
                );

                cmd.Parameters.AddWithValue("@FullName", TxtFullName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@ApartmentId", apartmentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }


            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Apartments SET IsOccupied = 1 WHERE Id = @id",
                    con
                );

                cmd.Parameters.AddWithValue("@id", apartmentId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Tenant added successfully.");
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteTernant_Click(object sender, EventArgs e)
        {
            if (dgvTenants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a tenant to delete.");
                return;
            }

            int tenantId = Convert.ToInt32(dgvTenants.SelectedRows[0].Cells["Id"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this tenant?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            string cs = ConfigurationManager.ConnectionStrings["ApartmentDbConnection"].ConnectionString;

            int apartmentId;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT ApartmentId FROM Tenants WHERE Id = @tenantId",
                    con
                );
                cmd.Parameters.AddWithValue("@tenantId", tenantId);
                con.Open();
                apartmentId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Tenants WHERE Id = @tenantId",
                    con
                );
                cmd.Parameters.AddWithValue("@tenantId", tenantId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Apartments SET IsOccupied = 0 WHERE Id = @apartmentId",
                    con
                );
                cmd.Parameters.AddWithValue("@apartmentId", apartmentId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadTenants();
            MessageBox.Show("Tenant deleted successfully.");


        }

        private void dgvTenants_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTenants.Rows[e.RowIndex];

                TxtFullName.Text = row.Cells["FullName"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();

                cmbApartments.Enabled = false;
            }
        }

        private void btnUpdateTenant_Click(object sender, EventArgs e)
        {
            if (dgvTenants.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a tenant to update.");
                return;
            }

            if (TxtFullName.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            int tenantId = Convert.ToInt32(dgvTenants.SelectedRows[0].Cells["Id"].Value);

            string cs = ConfigurationManager.ConnectionStrings["ApartmentDbConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Tenants SET FullName = @FullName, Phone = @Phone WHERE Id = @tenantId",
                    con
                );
                cmd.Parameters.AddWithValue("@FullName", TxtFullName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@tenantId", tenantId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadTenants();
            ClearTenantForm();
            MessageBox.Show("Tenant updated successfully.");

        }

        void ClearTenantForm()
        {
            TxtFullName.Clear();
            txtPhone.Clear();

            dgvTenants.ClearSelection();
            cmbApartments.Enabled = true;

        }

        private void btnAddTeant_Click(object sender, EventArgs e)
        {
            if (TxtFullName.Text == "" || txtPhone.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            int apartmentId = Convert.ToInt32(cmbApartments.SelectedValue);

            string cs = ConfigurationManager
                .ConnectionStrings["ApartmentDbConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Tenants (FullName, Phone, ApartmentId) VALUES (@FullName, @Phone, @ApartmentId)",
                    con
                );

                cmd.Parameters.AddWithValue("@FullName", TxtFullName.Text);
                cmd.Parameters.AddWithValue("@Phone", txtPhone.Text);
                cmd.Parameters.AddWithValue("@ApartmentId", apartmentId);

                con.Open();
                cmd.ExecuteNonQuery();
            }

           
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Apartments SET IsOccupied = 1 WHERE Id = @id",
                    con
                );

                cmd.Parameters.AddWithValue("@id", apartmentId);
                con.Open();
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Tenant added successfully.");
            this.Close();
        }

        private void cmbApartments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    
}
