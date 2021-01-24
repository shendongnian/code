    using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data source=|DataDirectory|\\crepeDB.accdb;"))
            {
                conn.Open();
                string query = @"select SUM(SQuantity) AS 'Total' From Sales where Sdate = Date()";
                System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand(query, conn);
               string result = cmd.ExecuteScalar().ToString();
                textBox1.Text = @result;
            }
