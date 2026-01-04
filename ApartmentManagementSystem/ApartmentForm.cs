using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using ApartmentManagementSystem.Model;

namespace ApartmentManagementSystem
{
    public partial class ApartmentForm : Form
    {
        public ApartmentForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ApartmentForm_Load(object sender, EventArgs e)
        {
            
            LoadApartments();

        }

        public void LoadApartments()
        {
            string cs = ConfigurationManager
                .ConnectionStrings["ApartmentDBConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT Id, ApartmentNo, Floor, IsOccupied FROM Apartments",
                    con
                );

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvApartments.DataSource = dt;
            }
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (txtApertmentNo.Text == "" || txtFloor.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            string cs = ConfigurationManager
         .ConnectionStrings["ApartmentDbConnection"]
         .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO Apartments (ApartmentNo, Floor, IsOccupied) VALUES (@ApartmentNo, @Floor, @IsOccupied)",
                    con
                );

                cmd.Parameters.AddWithValue("@ApartmentNo", txtApertmentNo.Text);
                cmd.Parameters.AddWithValue("@Floor", int.Parse(txtFloor.Text));
                cmd.Parameters.AddWithValue("@IsOccupied", chkIsOcuupied.Checked);

                con.Open();
                cmd.ExecuteNonQuery();
            }
            LoadApartments();
            btnClear.PerformClick();

            MessageBox.Show("Apartment added successfully.");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvApartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to delete.");
                return;
            }

            int id = Convert.ToInt32(dgvApartments.SelectedRows[0].Cells["Id"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to delete this apartment?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result != DialogResult.Yes)
                return;

            string cs = ConfigurationManager
                .ConnectionStrings["ApartmentDbConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM Apartments WHERE Id = @id",
                    con
                );

                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadApartments();
            btnClear.PerformClick();

            MessageBox.Show("Apartment deleted successfully.");
        }

        private void dgvApartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvApartments.Rows[e.RowIndex];

            txtApertmentNo.Text = row.Cells["ApartmentNo"].Value.ToString();
            txtFloor.Text = row.Cells["Floor"].Value.ToString();
            chkIsOcuupied.Checked = Convert.ToBoolean(row.Cells["IsOccupied"].Value);

            int apartmentId = Convert.ToInt32(row.Cells["Id"].Value);
            LoadTenantByApartment(apartmentId);
        }

       

        void LoadTenantByApartment(int apartmentId)
        {
            string cs = ConfigurationManager
                .ConnectionStrings["ApartmentDbConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT FullName, Phone FROM Tenants WHERE ApartmentId=@ApartmentId",
                    con
                );

                cmd.Parameters.AddWithValue("@ApartmentId", apartmentId);

                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTenantName.Text = reader["FullName"].ToString();
                        txtTenantPhone.Text = reader["Phone"].ToString();
                    }
                    else
                    {
                        txtTenantName.Text = "-- Empty --";
                        txtTenantPhone.Text = "";
                    }
                }
            }
        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvApartments.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to update.");
                return;
            }

            if (txtApertmentNo.Text == "" || txtFloor.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
                return;
            }

            int id = Convert.ToInt32(dgvApartments.SelectedRows[0].Cells["Id"].Value);

            string cs = ConfigurationManager
                .ConnectionStrings["ApartmentDbConnection"]
                .ConnectionString;

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(
                    "UPDATE Apartments SET ApartmentNo = @ApartmentNo, Floor = @Floor, IsOccupied = @IsOccupied WHERE Id = @id",
                    con
                );

                cmd.Parameters.AddWithValue("@ApartmentNo", txtApertmentNo.Text);
                cmd.Parameters.AddWithValue("@Floor", int.Parse(txtFloor.Text));
                cmd.Parameters.AddWithValue("@IsOccupied", chkIsOcuupied.Checked);
                cmd.Parameters.AddWithValue("@id", id);

                con.Open();
                cmd.ExecuteNonQuery();
            }

            LoadApartments();
            btnClear.PerformClick();

            MessageBox.Show("Apartment updated successfully.");


        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtApertmentNo.Clear();
            txtFloor.Clear();
            chkIsOcuupied.Checked = false;

            dgvApartments.ClearSelection();
        }

        private void btnOpenTenantForm_Click(object sender, EventArgs e)
        {
            TenantForm tenantForm = new TenantForm();
            tenantForm.Show();
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            RentPaymentForm frm = new RentPaymentForm();
            
            frm.Show();
        }

        

        private void dgvApartments_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
