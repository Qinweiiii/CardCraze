using System;
using System.Collections.Generic;
using System.Configuration;
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
            if (Session["User_id"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string name = System.IO.Path.GetFileName(ImageUpload.PostedFile.FileName);
            string type = name.Substring(name.LastIndexOf(".") + 1);
            Stream fs = ImageUpload.PostedFile.InputStream;
            byte[] content = ImageUpload.FileBytes;
            fs.Read(content, 0, content.Length);
            fs.Close();

            string connectionString = ConfigurationManager.ConnectionStrings["cardcrazeConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            // one table only includes imgID and image(byte[])
            // to ensure the one shown on the page and stored in the database is the final chosen one
            cmd.CommandText = "insert into product(Image_Content) values(@content)";
            cmd.CommandType = CommandType.Text;

            if (type == "jpg" || type == "gif" || type == "bmp" || type == "png" || type == "jpeg" || type == "png")
            {
                SqlParameter para = cmd.Parameters.Add("@content", SqlDbType.Image);
                para.Value = content;
                cmd.ExecuteNonQuery();
            }

            // after uploading the image into the databse, the background image of image-upload frame will be changed to uploaded one
            // another webform is created to read the image byte[] and restore back to image format
            cardImg.ImageUrl = "ImageCont.aspx";
            con.Close();
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            // here needs to use personal connection string
            string connectionString = ConfigurationManager.ConnectionStrings["cardcrazeConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = con.CreateCommand();
            con.Open();
            // if user wants to change anothter one image, after clicking "DELETE" button,
            // the record in DB is deleted
            cmd.CommandText = "DELETE FROM product WHERE imgID = (SELECT MAX(imgID) FROM product)";
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();

            con.Close();
            // the background image of image-upload frame will change back to default one
            cardImg.ImageUrl = "/assets/bg.png";
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            
            // empty checking
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

                // here needs to use personal connection string
                // cmd1 is used to fetch the image id info & cmd2 is for image info (byte[])
                // after fetching imgID & image info, cmd is used to insert all data filled into the table
                string connectionString = ConfigurationManager.ConnectionStrings["cardcrazeConnectionString"].ConnectionString;
                SqlConnection con = new SqlConnection(connectionString);

                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT MAX(imgID) FROM product", con);
                object imgIDobj = cmd.ExecuteScalar();
                decimal imgID = Convert.ToDecimal(imgIDobj);

                // load the image info which matched with the maximum imgID
                cmd = new SqlCommand("SELECT Image_Content FROM product WHERE imgID = (SELECT MAX(imgID) FROM product)", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                byte[] imageData = (byte[])dt.Rows[0]["Image_Content"];

                cmd = new SqlCommand("INSERT INTO products(prodName, Description, Price, Stock, Category, Type, ImageID, ImageCont, userid) values (@name, @desp, @price, @stock, @ctg, @type, @imgID, @imgCont, @userid)", con);
                cmd.Parameters.AddWithValue("@name", prodName.Text);
                cmd.Parameters.AddWithValue("@desp", prodDesp.Text);
                cmd.Parameters.AddWithValue("@price", price.Text);
                cmd.Parameters.AddWithValue("@stock", stock.Text);
                cmd.Parameters.AddWithValue("@ctg", ctgList.Text);
                cmd.Parameters.AddWithValue("@type", type.Text);
                cmd.Parameters.AddWithValue("@imgID", imgID);
                cmd.Parameters.AddWithValue("@imgCont", imageData);
                int userId = Convert.ToInt32(Session["User_id"]);
                cmd.Parameters.AddWithValue("@userid", userId);
                cmd.ExecuteNonQuery();

                // when finishing adding products, the page will be redirected to My Product page,
                // where can view the updated new product info
                Response.Redirect("MyProducts.aspx");
            }
            

        }
    }
}