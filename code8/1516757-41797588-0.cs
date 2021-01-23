    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            SelectByColor();
        }
        private void SelectByColor()
        {
            string conString = ConfigurationManager.ConnectionStrings["AdventureWorks2014ConnectionString"].ConnectionString;
            string query = "SELECT productid, name, color FROM production.product WHERE color=@pcolor";
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@pcolor", DropDownList1.SelectedItem.Value);
            using (SqlConnection con = new SqlConnection(conString))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataSet ds = new DataSet())
                    {
                        sda.Fill(ds);
                        GridView1.DataSource = ds;
                        GridView1.DataBind();
                    }
                }
            }
        }
    }
