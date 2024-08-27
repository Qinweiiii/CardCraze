using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace grp_assignment
{
    public partial class AddProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Here needs to use personal connection string
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ADKV1JSS\SQLEXPRESS01;Initial Catalog=CardCraze;Integrated Security=True");
        }

        protected void uploadButton_click(object sender, EventArgs e)
        {
            string name = System.IO.Path.GetFileName(ImageUpload.PostedFile.FileName);
            string type = name.Substring(name.LastIndexOf(".") + 1);
            Stream fs = ImageUpload.PostedFile.InputStream;
            byte[] content = ImageUpload.FileBytes;
            fs.Read(content, 0, content.Length);
            fs.Close();

            // Here needs to use personal connection string
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ADKV1JSS\SQLEXPRESS01;Initial Catalog=CardCraze;Integrated Security=True");
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            // One table only includes imgID and image(byte[])
            // to ensure the one shown on the page and stored in the database is the final chosen one
            cmd.CommandText = "insert into product(Image_Content) values(@content)";
            cmd.CommandType = CommandType.Text;

            if (type == "jpg" || type == "gif" || type == "bmp" || type == "png" || type == "jpeg" || type == "png")
            {
                SqlParameter para = cmd.Parameters.Add("@content", SqlDbType.Image);
                para.Value = content;
                cmd.ExecuteNonQuery();
            }

            // After uploading the image into the databse, the background image of image-upload frame will be changed to uploaded one
            // Another webform is created to read the image byte[] and restore back to image format
            cardImg.ImageUrl = "ImageCont.aspx";
            con.Close();
        }

        protected void deleteButton_click(object sender, EventArgs e)
        {
            // Here needs to use personal connection string
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ADKV1JSS\SQLEXPRESS01;Initial Catalog=CardCraze;Integrated Security=True");
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            // If user wants to change anothter one image, after clicking "DELETE" button,
            // the record in DB is deleted
            cmd.CommandText = "DELETE FROM CardCraze.dbo.product WHERE imgID = (SELECT MAX(imgID) FROM product)";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            con.Close();
            // the background image of image-upload frame will change back to default one
            cardImg.ImageUrl = "/assets/bg.png";
        }

        protected void saveButton_click(object sender, EventArgs e)
        {
            
            // Empty checking
            // if the bg-img of img-uplaod frame is still default one -> haven't confirmed to upload any image
            // if empty info exists, the error image will pop out and also the page will not be redirected
            if (prodName.Text == "" || prodDesp.Text == "" || price.Text == "" || stock.Text == "" || type.Text == "" || cardImg.ImageUrl == "/assets/bg.png")
            {
                errorMsg.Height = 10;
                errorMsg.Text = "You haven't completed to fill in the information.";
                errorMsg.ForeColor = System.Drawing.Color.Red;
                errorMsg.Font.Bold = true;
            }
            else
            {
                errorMsg.Height = 0;
                errorMsg.Text = "";

                // Here needs to use personal connection string
                // cmd1 is used to fetch the image id info & cmd2 is for image info (byte[])
                // after fetching imgID & image info, cmd is used to insert all data filled into the table
                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-ADKV1JSS\SQLEXPRESS01;Initial Catalog=CardCraze;Integrated Security=True");
                SqlCommand cmd = con.CreateCommand();
                SqlCommand cmd1 = con.CreateCommand();
                SqlCommand cmd2 = con.CreateCommand();
                con.Open();

                // maximum imgID means that the corresponding image the the latest-uploaded one -> final selected one
                cmd1.CommandText = "SELECT MAX(imgID) FROM CardCraze.dbo.product";
                cmd1.CommandType = CommandType.Text;
                object imgIDobj = cmd1.ExecuteScalar();
                decimal imgID = Convert.ToDecimal(imgIDobj);

                // load the image info which matched with the maximum imgID
                cmd2.CommandText = "SELECT Image_Content FROM CardCraze.dbo.product WHERE imgID = (SELECT MAX(imgID) FROM product)";
                cmd2.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter(cmd2);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                byte[] imageData = (byte[])dt.Rows[0]["Image_Content"];

                // load the actual values of each items and insert into the table
                cmd.CommandText = "INSERT INTO products(prodName, Description, Price, Stock, Category, Type, ImageID, ImageCont) values" +
                    "(@name, @desp, @price, @stock, @ctg, @type, @imgID, @imgCont)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@name", prodName.Text);
                cmd.Parameters.AddWithValue("@desp", prodDesp.Text);
                cmd.Parameters.AddWithValue("@price", price.Text);
                cmd.Parameters.AddWithValue("@stock", stock.Text);
                cmd.Parameters.AddWithValue("@ctg", ctgList.Text);
                cmd.Parameters.AddWithValue("@type", type.Text);
                cmd.Parameters.AddWithValue("@imgID", imgID);
                cmd.Parameters.AddWithValue("@imgCont", imageData);
                cmd.ExecuteNonQuery();
            }

            // when finishing adding products, the page will be redirected to My Product page,
            // where can view the updated new product info
            Response.Redirect("MyProducts.aspx");

        }
    }
}