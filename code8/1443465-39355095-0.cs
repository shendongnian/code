                using (var connection = new SqlConnection(Properties.Settings.Default.connectionString))
                {
                    connection.Open();
                    using (var fs = File.Open(Properties.Settings.Default.filePath, FileMode.Open))
                    {
                        var sql = "INSERT INTO TEST (Stream) VALUES (@fs)";
                        var dParams = new DynamicParameters();
                        dParams.Add("@fs", fs, DbType.Binary);
                        connection.Execute(sql, dParams);
                    }
                }
