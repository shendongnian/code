    string Sql = "BACKUP DATABASE " + metroComboBox1.Text + " TO DISK = '" + metroTextBox4.Text + "\\" + metroComboBox1.Text + "-" + DateTime.Now.Ticks.ToString() + ".bak'";
    using(SqlConnection CON = new SqlConnection("Data Source=DBS\\DB;Initial Catalog=" + metroTextBox1.Text + ";Integrated Security=True"))
    using(SqlCommand cmdBackup = new SqlCommand(Sql, CON))
    {   
        // open connection, execute command, close connection
        CON.Open();
        cmdBackup.ExecuteNonQuery();
        CON.Close();
    }
   
