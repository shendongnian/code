    public partial class registration : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["conn"].ToString()
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            txtFistname.Text = "";
            txtlastname.Text = "";
            TextBox1.Text = "";
            txtEmail.Text = "";
    
            txtcontac.Text = "";
            txtPassword.Text = "";
            txtconPassword.Text = "";
            SqlCommand cmd = new SqlCommand("insert into reg(FName,LName,Gender,email,contact,password,conpasswd) values('" + txtFistname.Text + "','" + txtlastname.Text + "','" + TextBox1.Text + "','" + txtEmail.Text + "','" + txtcontac.Text + "','" + txtPassword.Text + "','" + txtconPassword.Text + "')", con);
    
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("Data inserted successfully");
            }
    
            catch (Exception ex)
            {
                Response.Write("Somethings goes wrong" + ex.Message);
            }
        }
    }
