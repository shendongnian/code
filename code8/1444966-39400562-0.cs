    public partial class Login : System.Web.UI.Page
    {
        private string conString = "Server=.\\SQLEXPRESS;Database=TestDB;User Id=test; Password = woooow; ";
        protected void Button1_Click1(object sender, EventArgs e)
        {
            int count = 0;
            string cmdText = @"SELECT 1 FROM Login 
                               WHERE Username = @uname 
                                 AND Password = @pwd";
    
            using (SqlConnection cnn = new SqlConnection(conString))
            using (SqlCommand cmd = new SqlCommand(cmdText, cnn))      
            {
               cnn.Open();
               cmd.Parameters.Add("@uname", SqlDbType.NVarChar).Value = textBox1.Text;
               cmd.Parameters.Add("@pwd", SqlDbType.NVarChar).Value = textBox1.Text;
               using(SqlDataReader myReader = SelectCommand.ExecuteReader())
               {
                   while (myReader.Read())
                     count = count + 1;
               }
           }
           if (count == 1)
           {
              //open form
           }
           else
           {
    
           }
       }
    }
