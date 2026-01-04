using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace ApartmentAI 
{
    public partial class TenantWindow : Window
    {
       
        string connectionString = "Server=.\\SQLEXPRESS03;Database=ApartmentDB;Trusted_Connection=True;";
        int selectedTenantId = 0;
        private int apartmentId;

        

        public TenantWindow()
        {
            InitializeComponent();
            LoadApartments();
            LoadTenants();
        }

        
        public TenantWindow(int selectedApartmentId) : this()
        {
            apartmentId = selectedApartmentId;
        }

        void LoadApartments()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Id, ApartmentNo FROM Apartments WHERE IsOccupied = 0";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbApartments.ItemsSource = dt.DefaultView;
                cmbApartments.DisplayMemberPath = "ApartmentNo";
                cmbApartments.SelectedValuePath = "Id";
            }
        }

        void LoadApartments(int currentApartmentId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT Id, ApartmentNo
            FROM Apartments
            WHERE IsOccupied = 0 OR Id = @aptId";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@aptId", SqlDbType.Int).Value = currentApartmentId;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                cmbApartments.ItemsSource = dt.DefaultView;
                cmbApartments.DisplayMemberPath = "ApartmentNo";
                cmbApartments.SelectedValuePath = "Id";

            }
        }

                void LoadTenants()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT T.Id, T.FullName, T.Phone, T.ApartmentId, A.ApartmentNo
                    FROM Tenants T
                    INNER JOIN Apartments A ON T.ApartmentId = A.Id";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                dgTenants.ItemsSource = dt.DefaultView;
            }
        }

        
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFullName.Text) || string.IsNullOrEmpty(txtPhone.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            
            if (cmbApartments.SelectedValue == null)
            {
                MessageBox.Show("\r\nPlease choose an apartment.");
                return;
            }

             apartmentId = Convert.ToInt32(cmbApartments.SelectedValue);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                
                
                SqlTransaction transaction = con.BeginTransaction();

                try
                {
                    
                    string insertQuery = "INSERT INTO Tenants (FullName, Phone, ApartmentId) VALUES (@name, @phone, @aptId)";
                    SqlCommand cmdInsert = new SqlCommand(insertQuery, con, transaction);
                    cmdInsert.Parameters.AddWithValue("@name", txtFullName.Text);
                    cmdInsert.Parameters.AddWithValue("@phone", txtPhone.Text);
                    cmdInsert.Parameters.AddWithValue("@aptId", apartmentId);
                    cmdInsert.ExecuteNonQuery();

                    string updateQuery = "UPDATE Apartments SET IsOccupied = 1 WHERE Id = @aptId";
                    SqlCommand cmdUpdate = new SqlCommand(updateQuery, con, transaction);
                    cmdUpdate.Parameters.AddWithValue("@aptId", apartmentId);
                    cmdUpdate.ExecuteNonQuery();

                    
                    transaction.Commit();
                    MessageBox.Show("A tenant has been added and the apartment is marked as occupied.");
                    this.DialogResult = true;
                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Occuped Error: " + ex.Message);
                }
            }

            LoadTenants();
            LoadApartments(); 
            ClearForm();
        }


        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTenantId == 0)
            {
                MessageBox.Show("Please select a tenant to delete.");
                return;
            }

            if (MessageBox.Show(
                "Are you sure you want to delete this tenant?",
                "Approval",
                MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlTransaction transaction = con.BeginTransaction();

                    try
                    {
                        int apartmentId = 0;

                    
                        SqlCommand cmdGetApt = new SqlCommand(
                            "SELECT ApartmentId FROM Tenants WHERE Id = @tId",
                            con, transaction);
                        cmdGetApt.Parameters.AddWithValue("@tId", selectedTenantId);

                        object result = cmdGetApt.ExecuteScalar();
                        if (result != null)
                            apartmentId = Convert.ToInt32(result);

                        
                        SqlCommand cmdDeletePayments = new SqlCommand(
                            "DELETE FROM RentPayments WHERE TenantId = @tId",
                            con, transaction);
                        cmdDeletePayments.Parameters.AddWithValue("@tId", selectedTenantId);
                        cmdDeletePayments.ExecuteNonQuery();

                        SqlCommand cmdDeleteTenant = new SqlCommand(
                            "DELETE FROM Tenants WHERE Id = @Id",
                            con, transaction);
                        cmdDeleteTenant.Parameters.AddWithValue("@Id", selectedTenantId);
                        cmdDeleteTenant.ExecuteNonQuery();

                        if (apartmentId > 0)
                        {
                            SqlCommand cmdUpdate = new SqlCommand(
                                "UPDATE Apartments SET IsOccupied = 0 WHERE Id = @aptId",
                                con, transaction);
                            cmdUpdate.Parameters.AddWithValue("@aptId", apartmentId);
                            cmdUpdate.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        MessageBox.Show("Tenant deleted and apartment is now vacant.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }

                LoadTenants();
                LoadApartments();
                ClearForm();
            }
        }



        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTenantId == 0)
            {
                MessageBox.Show("Please select a tenant.");
                return;
            }

            if (cmbApartments.SelectedValue == null)
            {
                MessageBox.Show("Please select an apartment.");
                return;
            }

            string fullName = txtFullName.Text.Trim();
            string phone = txtPhone.Text.Trim();
            int newApartmentId = Convert.ToInt32(cmbApartments.SelectedValue);
            int oldApartmentId = 0;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlTransaction tr = con.BeginTransaction();

                try
                {
                    SqlCommand cmdOld = new SqlCommand(
                        "SELECT ApartmentId FROM Tenants WHERE Id = @id",
                        con, tr);
                    cmdOld.Parameters.Add("@id", SqlDbType.Int).Value = selectedTenantId;

                    object result = cmdOld.ExecuteScalar();
                    if (result != null)
                        oldApartmentId = Convert.ToInt32(result);

                    SqlCommand cmdUpdate = new SqlCommand(
                    @"UPDATE Tenants
                      SET FullName = @n,
                          Phone = @p,
                          ApartmentId = @a
                      WHERE Id = @id",
                    con, tr);

                    cmdUpdate.Parameters.Add("@n", SqlDbType.NVarChar, 100).Value = fullName;
                    cmdUpdate.Parameters.Add("@p", SqlDbType.NVarChar, 20).Value = phone;
                    cmdUpdate.Parameters.Add("@a", SqlDbType.Int).Value = newApartmentId;
                    cmdUpdate.Parameters.Add("@id", SqlDbType.Int).Value = selectedTenantId;
                    cmdUpdate.ExecuteNonQuery();

                    if (oldApartmentId != newApartmentId)
                    {
                        SqlCommand cmdFree = new SqlCommand(
                            "UPDATE Apartments SET IsOccupied = 0 WHERE Id = @id",
                            con, tr);
                        cmdFree.Parameters.Add("@id", SqlDbType.Int).Value = oldApartmentId;
                        cmdFree.ExecuteNonQuery();

                        SqlCommand cmdOcc = new SqlCommand(
                            "UPDATE Apartments SET IsOccupied = 1 WHERE Id = @id",
                            con, tr);
                        cmdOcc.Parameters.Add("@id", SqlDbType.Int).Value = newApartmentId;
                        cmdOcc.ExecuteNonQuery();
                    }

                    tr.Commit();
                    MessageBox.Show("Tenant updated successfully.");
                }
                catch (Exception ex)
                {
                    tr.Rollback();
                    MessageBox.Show("Update error: " + ex.Message);
                }
            }

            LoadTenants();
            LoadApartments();
            ClearForm();
        }

        private void dgTenants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgTenants.SelectedItem == null) return;

            DataRowView row = (DataRowView)dgTenants.SelectedItem;

            selectedTenantId = (int)row["Id"];
            txtFullName.Text = row["FullName"].ToString();
            txtPhone.Text = row["Phone"].ToString();

            int currentApartmentId = Convert.ToInt32(row["ApartmentId"]);
            LoadApartments(currentApartmentId);
            cmbApartments.SelectedValue = currentApartmentId;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }

        void ClearForm()
        {
            txtFullName.Clear();
            txtPhone.Clear();
            cmbApartments.SelectedIndex = -1;
            selectedTenantId = 0;
            dgTenants.SelectedItem = null;
        }
    }
}