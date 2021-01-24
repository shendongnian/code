            string result = string.Empty;
            using (var connection = new OleDbConnection("Provider=Microsoft.JET.OLEDB.4.0;" + @"data source = employee.mdb"))
            {
                try
                {
                    connection.Open();
                    foreach (KeyValuePair<string, string> pair in dictionary)
                    {
                        string query = "SELECT * FROM employeeTable WHERE ID=@id";
                        var command = new OleDbCommand(query, connection);
                        //command.Parameters.Add(new OleDbParameter("@ID", pair.Value));
                         command.Parameters.Add("@id", OleDbType.BSTR).Value = pair.Value;
                        var reader = command.ExecuteReader();
                        //result = reader.ToString();
                        while (reader.Read())
                        {
                            result += reader[1].ToString() + "\r\n";
                        }
                        reader.Close();
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    Response.Write("Exception: " + ex.Message);
                }
            }
