    public partial class _Default : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection("Data Source=ADMIN-PC\\SQLEXPRESS;Initial Catalog=register;Integrated Security=True");
    
        protected void Page_Load(object sender, EventArgs e)
        {
    
        }
    
        public void Button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (uniqueEmail()==true)
            {
                cmd.CommandText = "update registeruser set email='" + TextBox1.Text + "', password='" + TextBox2.Text + "' where email='" + TextBox1.Text + "'";
            }
            else 
            {
                cmd.CommandText = "insert into registeruser values('" + TextBox1.Text + "', '" + TextBox2.Text + "')";
            }
    
            cmd.ExecuteNonQuery();
            con.Close();
    
        }
        public bool uniqueEmail()
        {
            string stremail;
            string querye = "select count(email) as email from registeruser where email = '" +TextBox1.Text+ "'";
            SqlCommand cmd = new SqlCommand(querye, con);
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read()) 
            {
                try
                {
                    stremail = dr["email"].ToString();
                    return(stremail != "0");
                    if (stremail != "0")
                    {
                        //errlblemail.Text = "email already exist";
                        return false;
                    }
    
                }
                catch (Exception e)
                {
                    string message = "error";
                    message += e.Message;
                }
                finally
                {
                    dr.Close();
                }
            }
    
            return true;
    
    
        }
    }
