using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

namespace grp_assignment
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void upload_click(object sender, EventArgs e)
        {
            string name = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName); 
            string type = name.Substring(name.LastIndexOf(".") + 1);
            Stream fs = FileUpload1.PostedFile.InputStream;
            byte[] content = FileUpload1.FileBytes;
            fs.Read(content, 0, content.Length);
            fs.Close();

            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ADKV1JSS\SQLEXPRESS01;Initial Catalog=CardCraze;Integrated Security=True");
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            cmd.CommandText = "insert into product(Image_Content) values(@content)";  
            cmd.CommandType = CommandType.Text;

            if (type == "jpg" || type == "gif" || type == "bmp" || type == "png")
            {
                SqlParameter para = cmd.Parameters.Add ("@content", SqlDbType.Image);
                para.Value = content;
                cmd.ExecuteNonQuery();
            }

            Image1.ImageUrl = "ImageCont.aspx";

        }

        protected void upload_click2(object sender, EventArgs e)
        {
            
        }
    }
}