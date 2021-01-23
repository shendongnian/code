    using System.Data.OleDb;
    using System.Configuration;
    
    public partial class Default2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["northwind"].ToString();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "insert into[Table1](pName, pEmail)values(@nm, @em)";
            cmd.Parameters.AddWithValue("@nm", TextBox1.Text);
            cmd.Parameters.AddWithValue("@em", TextBox2.Text);
            cmd.Connection = con;
            int a = cmd.ExecuteNonQuery();
            if (a>0)
            {
                Label1.Text = "Inserted Sucessfully!";
            }
        }
    }
