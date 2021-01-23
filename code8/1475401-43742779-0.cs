             using (var context = new SampleContext())
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = "GetData";
                    command.CommandType = CommandType.StoredProcedure;
                    context.Database.OpenConnection();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        var ds = new DataSet();
                        adapter.Fill(ds);
                        return ds;
                    }
                }
            }
