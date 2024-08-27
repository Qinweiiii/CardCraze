using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace grp_assignment
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Go_Register(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void On_Login(object sender, EventArgs e)
        {
            string email = EmailTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ErrorMessage.Text = "Email and Password fields are required.";
                return;
            }

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ADKV1JSS\SQLEXPRESS01;Initial Catalog=CardCraze;Integrated Security=True;Encrypt=False");
                con.Open();
                string checkUserQuery = "SELECT COUNT(*) FROM [user] WHERE User_email = @User_email AND User_password = @User_password";
                SqlCommand cmd = new SqlCommand(checkUserQuery, con);
                cmd.Parameters.AddWithValue("@User_email", email);
                cmd.Parameters.AddWithValue("@User_password", password);
                int userExists = (int)cmd.ExecuteScalar();

                if (userExists == 0)
                {
                    ErrorMessage.Text = "Invalid email or password.";
                    return;
                }
                Session["User_email"] = email;
                Response.Redirect("Test.aspx");
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}