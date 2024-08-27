using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace grp_assignment
{
    public partial class MyProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindRepeater();
            }
        }

        private void BindRepeater()
        {
            // Here needs to use personal connection string
            SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-ADKV1JSS\SQLEXPRESS01;Initial Catalog=CardCraze;Integrated Security=True");
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand("SELECT prodID, prodName, Price, Stock, ImageCont, Description FROM products", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        Repeater1.DataSource = dt;
                        Repeater1.DataBind();
                    }
                }
            }
        }

        protected void addButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }
    }
}