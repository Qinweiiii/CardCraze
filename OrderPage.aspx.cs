using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace grp_assignment
{
    public partial class OrderPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Initialize the state based on default selection
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
        //Go home from back btn
        protected void click_Home(object sender, EventArgs e)
        {
            Response.Redirect("");
        }
        //Click pay button
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
            click_Home(sender, e);
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