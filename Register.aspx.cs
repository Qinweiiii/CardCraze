using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace grp_assignment
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Go_Login(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void On_Register(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string name = NameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();
            string confirmPassword = ConfirmPasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                ErrorMessage.Text = "All fields are required.";
                return;
            }

            if (password != confirmPassword)
            {
                ErrorMessage.Text = "Passwords do not match.";
                return;
            }


            try {
                string connectionString = ConfigurationManager.ConnectionStrings["cardcrazeConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                string checkEmailQuery = "SELECT COUNT(*) FROM [user] WHERE User_email = @User_email";
                SqlCommand checkCmd = new SqlCommand(checkEmailQuery, con);
                checkCmd.Parameters.AddWithValue("@User_email", email);
                int emailExists = (int)checkCmd.ExecuteScalar();

                if (emailExists > 0)
                {
                    ErrorMessage.Text = "Email already exists.";
                    return;
                }

                // insert new user
                string insertQuery = "INSERT INTO [user] (User_email, User_password) VALUES (@User_email, @User_password)";
                SqlCommand cmd = new SqlCommand(insertQuery, con);
                cmd.Parameters.AddWithValue("@User_email", email);
                cmd.Parameters.AddWithValue("@User_password", password);
                cmd.ExecuteNonQuery();
                Response.Redirect("Login.aspx");
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}