            using (OracleConnection con = new OracleConnection(source))
            {
                con.Open();
                using (var cmd = con.CreateCommand())
                {
                    cmd.BindByName = true;
                    cmd.CommandText = "select :NAME from dual";
                    cmd.Parameters.Add("NAME", "Hello World!");
                    /*
                    command.Parameters.Add(
                      new OracleParameter("NAME", OracleDbType.Varchar2, "Hello World!", ParameterDirection.Input)
                     );
                    */
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string val = rdr.GetString(0);
                            MessageBox.Show(val);
                        }
                    }
                }
            }
