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
    public partial class Order : System.Web.UI.Page
    {
        string productId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            if (Request.QueryString["prodID"] != null)
            {
                productId = Request.QueryString["prodID"];
                string connectionString = ConfigurationManager.ConnectionStrings["cardcrazeConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT prodName, Price, Stock, ImageCont, Type, Description FROM products WHERE prodID = @prodID", con);
                cmd.Parameters.AddWithValue("@prodID", productId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    cardname.Text = reader["prodName"].ToString();
                    cardpic.ImageUrl = "data:image/png;base64," + Convert.ToBase64String((byte[])reader["ImageCont"]);
                    cardprice.Text = "RM " + reader["Price"].ToString();
                    Label1.Text = "RM " + reader["Price"].ToString();
                    total.Text = "RM " + (Convert.ToInt32(reader["Price"]) + 10).ToString();
                }
            }
            else
            {
                Response.Redirect("Store.aspx");
            }
            if (!IsPostBack)
            {
                tngcontainer.Attributes["class"] = "tngcontainer ";
                bankcontainer.Attributes["class"] = "bankcontainer selected";
                bank.Checked = true;
                tng.Checked = false;
                cardno.Visible = true;
                cardcvv.Visible = true;
                cardex.Visible = true;
                phone.Visible = false;
                pw.Visible = false;
            }
        }
      
        protected void click_Pay(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(r_name.Text) || string.IsNullOrEmpty(r_addr.Text) || string.IsNullOrEmpty(r_c.Text) || string.IsNullOrEmpty(r_pc.Text))
            {
                string script = $"alert('{"Please fill in all fields to proceed"}');";
                ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                return;
            }
            if (bank.Checked)
            {
                if (string.IsNullOrEmpty(r_cnumber.Text) || string.IsNullOrEmpty(r_exdate.Text) || string.IsNullOrEmpty(r_cvv.Text))
                {
                    string script = $"alert('{"Please fill in your payment credentials"}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                    return;
                }
            }
            else if (tng.Checked)
            {
                if (string.IsNullOrEmpty(r_phone.Text) || string.IsNullOrEmpty(r_pw.Text))
                {
                    string script = $"alert('{"Please fill in your payment credentials"}');";
                    ClientScript.RegisterStartupScript(this.GetType(), "Alert", script, true);
                    return;
                }
            }

            // check the stock of the card, if > 0, decrement 1, if = 1, delete the record
            int stock = 0;
            string connectionString = ConfigurationManager.ConnectionStrings["cardcrazeConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();

            string checkStockQuery = "SELECT Stock FROM products WHERE prodID = @prodID;";
            SqlCommand cmd = new SqlCommand(checkStockQuery, con);
            cmd.Parameters.AddWithValue("@prodID", Convert.ToInt32(productId));
            stock = Convert.ToInt32(cmd.ExecuteScalar());
            if (stock > 0)
            {
                if (stock == 1)
                {
                    string deleteQuery = "DELETE FROM products WHERE prodID = @prodID";
                    cmd = new SqlCommand(deleteQuery, con);
                    cmd.Parameters.AddWithValue("@prodID", productId);
                    cmd.ExecuteNonQuery();
                }
                else
                {
                    // decrement stock by 1
                    string updateStockQuery = "UPDATE products SET Stock = Stock - 1 WHERE prodID = @prodID";
                    cmd = new SqlCommand(updateStockQuery, con);
                    cmd.Parameters.AddWithValue("@prodID", productId);
                    cmd.ExecuteNonQuery();
                }
            }
            Response.Redirect("Store.aspx");
        }

        protected void click_Home(object sender, EventArgs e)
        {
            Response.Redirect("Store.aspx");
        }

        protected void click_rb(object sender, EventArgs e)
        {
            if (tng.Checked)
            {
                tngcontainer.Attributes["class"] = "tngcontainer selected";
                bankcontainer.Attributes["class"] = "bankcontainer";
                cardno.Visible = false;
                cardcvv.Visible = false;
                cardex.Visible = false;
                phone.Visible = true;
                pw.Visible = true;
            }
            else if (bank.Checked)
            {
                tngcontainer.Attributes["class"] = "tngcontainer";
                bankcontainer.Attributes["class"] = "bankcontainer selected";
                cardno.Visible = true;
                cardcvv.Visible = true;
                cardex.Visible = true;
                phone.Visible = false;
                pw.Visible = false;
            }
        }
    }
}