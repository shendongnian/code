    private void button1_Click(object sender, EventArgs e)
    {
        try
        {
            string oradb = "Data Source=ORCL;User Id=hr; Password=123;";
            
            // Use the using statements around disposable objects....
            using(OracleConnection conn = new OracleConnection(oradb))
            using(OracleCommand cmd = new OracleCommand())
            {
                 conn.Open();
                 // These two parameters could be passed directly in the
                 // OracleCommand constructor....
                 cmd.Connection = conn;
                 cmd.CommandText = "select name from std where cgpa=2.82;";
                 // Again using statement around disposable objects
                 using(OracleDataReader dr = cmd.ExecuteReader())
                 {
                      // Check if you have a record or not
                      if(dr.Read())
                          textBox1.Text = dr.GetString(0);
                 }
            }
        }
        catch (Exception ex) { MessageBox.Show("\n"+ex); }
    }
