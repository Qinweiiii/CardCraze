using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace grp_assignment
{
    public partial class ImageCont : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string imgid = Request.QueryString["imgid"];
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ADKV1JSS\SQLEXPRESS01;Initial Catalog=CardCraze;Integrated Security=True");
            // get the maximum prodID - matches with the latest-uploaded image
            SqlCommand cmd1 = new SqlCommand("select Image_Content from product where imgID = (SELECT MAX(imgID) FROM product)", con);
            con.Open();
            SqlDataReader sdr = cmd1.ExecuteReader();
            if (sdr.Read())
            {
                // restore the image from bytes to picture
                Response.BinaryWrite((byte[])sdr["Image_Content"]);
            }
            Response.End();
        }
    }
}