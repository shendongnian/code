    using (OleDbConnection con = new OleDbConnection(conStr))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        using (OleDbDataAdapter oda = new OleDbDataAdapter())
                        {
                            DataTable dt = new DataTable();
                    cmd.CommandText = "SELECT * From [" + sheetName  + "]";
                            cmd.Connection = con;
                            con.Open();
                            oda.SelectCommand = cmd;
                            oda.Fill(dt);
                            con.Close();
      DataTable dtnew = new DataTable();
                                dtnew=dt.Clone();
                                if (dt.Rows.Count > 0)
                                {
                               for (int i = fromrow; i < dt.Rows.Count; i++)
                                    {
                                        DataRow dtRow = dt.Rows[i];
                                        dtnew.ImportRow(dtRow);
                                    }
