                CustomClass item = new CustomClass();
            String sql_user = "SELECT c1.ID, c1.SHORT_NAME, ao1.NAME, c1.REGON FROM (tabel1 c1 LEFT JOIN tabel2 ao1 ON c1.ID = ao1.ID WHERE c1.ID = @id";
            using (var conn = new OleDbConnection("connectionString"))
            {
                conn.Open();
                using (var cmd = new OleDbCommand(sql_user, conn))
                {
                    cmd.Parameters.Add("@id", OleDbType.Integer).Value = Request.QueryString["a"];
                    cmd.Prepare();
                    var reader = cmd.ExecuteReader();
                    if(reader.Read())
                    {
                        item.Id = (int)reader["ID"];
                        item.ShortName = reader["SHORT_NAME"].ToString();
                        item.Name= reader["NAME"].ToString();
                        item.Regon = (int)reader["REGON"];
                    }
                    conn.Close();
                }
            }
