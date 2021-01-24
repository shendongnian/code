    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Web.Services;
    using System.Configuration;
    using System.Data;
    using MySql.Data.MySqlClient;
    
    public partial class Editcar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            using (MySqlConnection con = new MySqlConnection(constr))
            {
                var id = Request.QueryString["id"];
                string selectqurey = "SELECT * FROM product WHERE id=" + @id;
                MySqlCommand cmmd = new MySqlCommand(selectqurey);
                cmmd.Connection = con;
                cmmd.CommandType = CommandType.Text;
                con.Open();
                cmmd.ExecuteNonQuery();
                MySqlDataAdapter da = new MySqlDataAdapter(cmmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    newid.Text = dr["id"].ToString();
                    carmake.Text = dr["car_make"].ToString();
                    carmodel.Text = dr["car_model"].ToString();
                    price.Text = dr["unitprice"].ToString();
                    d_price.Text = dr["discountprice"].ToString();
                    image.Text = dr["image"].ToString();
                    qnty.Text = dr["quantity"].ToString();
                    avbl.Text = dr["availability"].ToString();
                    details.Text = dr["details"].ToString();
                    year.Text = dr["year"].ToString();
                    special.Text = dr["special"].ToString();
                }
            }
        }
    }
    public void button_click(object sender, EventArgs e)
    {
       
            string constor = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
        MySqlConnection conn = new MySqlConnection(constor);
       
        string sql = "Update product SET car_make=@carmake, car_model=@carmodel, UnitPrice=@price, Discountprice=@d_price, image=@image, Quantity=@quantity, availability=@avail, details=@details, year=@year, special=@special  WHERE id= @id";
        var cmd = new MySqlCommand(sql, conn);
        conn.Open();
        cmd.Parameters.AddWithValue("@carmake", carmake.Text);
        cmd.Parameters.AddWithValue("@carmodel", carmodel.Text);
        cmd.Parameters.AddWithValue("@price", price.Text);
        cmd.Parameters.AddWithValue("@d_price", d_price.Text); // put zero if no discount
        cmd.Parameters.AddWithValue("@image", image.Text);
        cmd.Parameters.AddWithValue("@quantity", qnty.Text);
        cmd.Parameters.AddWithValue("@avail", avbl.Text);
        cmd.Parameters.AddWithValue("@details", details.Text);
        cmd.Parameters.AddWithValue("@year", year.Text);
        cmd.Parameters.AddWithValue("@special", special.Text);
        cmd.Parameters.AddWithValue("@id", newid.Text);
        var ex = cmd.ExecuteNonQuery();
        if (ex == 1)
        {
            Response.Redirect("AdminList.aspx");
        }
        else
        {
            Response.Write("Error");
        }
        conn.Close();
        }
      }
