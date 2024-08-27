using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace grp_assignment
{
    public partial class Store : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // get user id from session
            if (Session["User_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                BindProductData();
            }
        }

        private void BindProductData()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cardcrazeConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT prodID, prodName, Price, Stock, ImageCont, Type, Category, Description FROM products", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Repeater1.DataSource = dt;
            Repeater1.DataBind();
        }

        protected void AllButton_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["cardcrazeConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            Button clickedButton = sender as Button;
            string category = clickedButton.CommandArgument;

            // reset CSS class for all buttons
            AllButton.CssClass = "category-button";
            KpopButton.CssClass = "category-button";
            NbaButton.CssClass = "category-button";

            // set active class for the clicked button
            clickedButton.CssClass = "category-button active";

            if (clickedButton.CommandArgument == "all")
            {
                string query = "SELECT prodID, prodName, Price, Stock, ImageCont, Type, Category, Description FROM products";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }

            // only KPOP cards
            if (clickedButton.CommandArgument == "kpop")
            {
                  /*  string query = "SELECT ProdName, ProdPrice, ProdCategory, ProdType, ProdImageUrl FROM card WHERE ProdCategory = 'Kpop'";*/
                string query = "SELECT prodID, prodName, Price, Stock, ImageCont, Type, Category, Description FROM products WHERE Category = 'K-POP Card'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            // NBA cards
            if (clickedButton.CommandArgument == "nba")
            {
                
                  /*  string query = "SELECT ProdName, ProdPrice, ProdCategory, ProdType, ProdImageUrl FROM card WHERE ProdCategory = 'NBA'";*/
                string query = "SELECT prodID, prodName, Price, Stock, ImageCont, Type, Category, Description FROM products WHERE Category = 'Sports Stars Card'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
            if (clickedButton.CommandArgument == "pokemon")
            {
                
                /*  string query = "SELECT ProdName, ProdPrice, ProdCategory, ProdType, ProdImageUrl FROM card WHERE ProdCategory = 'NBA'";*/
                string query = "SELECT prodID, prodName, Price, Stock, ImageCont, Type, Category, Description FROM products WHERE Category = 'Pokeman Card'";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // Redirect to where?
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddProduct.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string productId = btn.CommandArgument;
            Response.Redirect($"Order.aspx?prodID={productId}");
        }
    }
}