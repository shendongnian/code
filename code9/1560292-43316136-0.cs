    public static bool uniqueEmail(string email)
    {
            string stremail;
            string querye = "select count(email) as email from register where 
            email = '" + email + "'";
            //Remaining Code
    }
     public static void Button1_Click(object sender, EventArgs e)
     {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (uniqueEmail(TextBox1.Text)) == true) 
           //Remaining Code
      }
    
