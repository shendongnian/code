            const string sql = "INSERT INTO table1 (column1) VALUES (@p0)";
            using (var sqlCommand = new SqlCommand(sql, connection, transaction))
            {
                var param1 = sqlCommand.Parameters.Add("@p0", SqlDbType.Int);
                foreach (var row in table)
                {
                    param1.Value = row["value"];
                    sqlCommand.ExecuteNonQuery();
                }
            }
