            var con = new OracleConnection(source);
            using (con)
            {
                con.Open();
                var cmd = con.CreateCommand();
                cmd.CommandText = "SELECT :NAME FROM dual";
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Parameters.AddWithValue("NAME", "Hello World!");
                using (cmd)
                {
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        string val = rdr.GetString(0);
                        MessageBox.Show(val);
                    }
                }
            }
