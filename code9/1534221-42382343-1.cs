    using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data source=|DataDirectory|\\crepeDB.accdb;"))
        {
            conn.Open();
            string query = @"select SUM(SQuantity) From Sales where Sdate = @datetime";
            System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(query, conn);
            cmd.Parameters.Add("@datetime", System.Data.OleDb.OleDbType.Date).Value = dateTimePicker1.Value.ToShortDateString();
            //cmd.Parameters.Add("@datetime2", System.Data.OleDb.OleDbType.Date).Value = dateTimePicker2.Value;
            //cmd.ExecuteNonQuery();
            //string result = cmd.ExecuteScalar().ToString();
            textBox1.Text = cmd.ExecuteScalar().ToString();
        }
