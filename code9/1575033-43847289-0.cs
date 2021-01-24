    using (var sqlCom = new MySqlCommand(agentsQuery, Connect.Connection))
                    {
                        sqlCom.ExecuteNonQuery();
                        var dt = new DataTable();
                        var dataAdapter = new MySqlDataAdapter(sqlCom);
                        dataAdapter.Fill(dt);
                        MyData = dt;
                    }
