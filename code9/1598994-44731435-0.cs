    private void button9_Click(object sender, EventArgs e)
    {
        try
        {
            string ConnString = (@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\temp\\names.accdb;Persist Security Info=False");
            using (OleDbConnection Conn = new OleDbConnection(ConnString))
            {
                //Conn.Close();//severl times connection has been open
                Conn.Open();
                DataSet ds = new DataSet();
                ds.ReadXml(@"c:\\temp\\my123.xml");
                OleDbCommand cmd = new OleDbCommand();
                //OleDbCommand cmd1 = new OleDbCommand();
                DataTable dtCSV = new DataTable();
                dtCSV = ds.Tables[0];
                cmd.Connection = Conn;
                cmd.CommandType = CommandType.Text;
                //cmd1.Connection = Conn;
                //cmd1.CommandType = CommandType.Text;
    
                //Conn.Open();
    
                for (int row = 0; row <= dtCSV.Rows.Count - 1; row++)
                {
                    //for (int col = 0; col < dtCSV.Columns.Count - 1; col++)
                    //{
                    //    //cmd.CommandText = ("INSERT INTO  tab1 ( field1, field2) VALUES (dtCSV.Rows ,dtCSV.Columns)");
                    //}
                    cmd.Parameters.Clear();
                    if (dtCSV.Columns.Count > 1)
                    {
                        cmd.Parameters.Add(dtCSV.Rows[row][0].ToString());
                        cmd.Parameters.Add(dtCSV.Rows[row][1].ToString());
    
                        cmd.CommandText = ("INSERT INTO  tab1 ( field1, field2) VALUES (? , ?)");
                        cmd.ExecuteNonQuery();
                    }
    
                }
                        
                //Conn.Close();
            }
        }
        catch (Exception ex)
        {
            richTextBox1.Text = richTextBox1.Text + "\n Error " + ex + "\n"; ;
        }
    }
