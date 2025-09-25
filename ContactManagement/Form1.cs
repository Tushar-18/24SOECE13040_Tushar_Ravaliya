using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManagement
{
    public partial class Form1 : Form
    {
        
        private readonly string connectionString;

        public Form1()
        {
            InitializeComponent();
            connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\btech\dotnet\24SOECE13040_Tushar_Ravaliya\ContactManagement\ContactsDB.mdf;Integrated Security=True ";
        }

      
        private void Form1_Load(object sender, EventArgs e)
        {
            LoadContacts();
        }

        private void LoadContacts()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    
                    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Contacts ORDER BY FirstName", con);
                    DataTable dt = new DataTable();
                    da.Fill(dt); 

                    
                    dataGridViewContacts.DataSource = dt;

                    
                    dataGridViewContacts.Columns["ContactID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load contacts. Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchContacts(string searchTerm)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    
                    string query = "SELECT * FROM Contacts WHERE FirstName LIKE @searchTerm OR LastName LIKE @searchTerm ORDER BY FirstName";

                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        
                        da.SelectCommand.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");

                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        
                        dataGridViewContacts.DataSource = dt;

                        
                        if (dataGridViewContacts.Columns.Contains("ContactID"))
                        {
                            dataGridViewContacts.Columns["ContactID"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to search contacts. Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFirstName.Text))
            {
                MessageBox.Show("First Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Use parameterized queries to prevent SQL Injection attacks
                    string query = "INSERT INTO Contacts (FirstName, LastName, Email, Phone) VALUES (@FirstName, @LastName, @Email, @Phone)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Contact added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadContacts(); // Refresh the grid to show the new contact
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to add contact. Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(lblSelectedContactID.Text) || lblSelectedContactID.Text == "0")
            {
                MessageBox.Show("Please select a contact from the list to update.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Contacts SET FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone WHERE ContactID = @ContactID";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@ContactID", lblSelectedContactID.Text);
                    cmd.Parameters.AddWithValue("@FirstName", txtFirstName.Text.Trim());
                    cmd.Parameters.AddWithValue("@LastName", txtLastName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Phone", txtPhone.Text.Trim());

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Contact updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadContacts(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to update contact. Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblSelectedContactID.Text) || lblSelectedContactID.Text == "0")
            {
                MessageBox.Show("Please select a contact from the list to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this contact?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Contacts WHERE ContactID = @ContactID";
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@ContactID", lblSelectedContactID.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("Contact deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearFields();
                        LoadContacts(); // Refresh the grid
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to delete contact. Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dataGridViewContacts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Make sure a valid row is clicked
            {
                DataGridViewRow row = this.dataGridViewContacts.Rows[e.RowIndex];

                
                lblSelectedContactID.Text = row.Cells["ContactID"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtPhone.Text = row.Cells["Phone"].Value.ToString();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            lblSelectedContactID.Text = "0";
            txtFirstName.Focus(); 
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text;
            SearchContacts(searchTerm);
        }
    }
}
