            using (var conn = new SqlConnection(connectionString: ""))
            {
                conn.Open();
                using (var cmd = new SqlCommand(cmdText: "cmdText", connection: conn))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //
                        }
                    }
                }
            }
