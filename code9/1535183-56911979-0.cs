    public bool CopyFileToPostgress(String tableName, String filePath,String delimiter)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Host=xx.xx.xx.xx;port=xxxx;Database=xxxx;Username=xxxx;Password=xxxx;Pooling=false;Timeout=300;CommandTimeout=300");
            NpgsqlCommand cmd = new NpgsqlCommand();
            Boolean result = true;
            try
            {
                conn.Open();
                NpgsqlTransaction transaction = conn.BeginTransaction();
                if (File.Exists(filePath))
                {
                    try
                    {
                        NpgsqlCommand command = new NpgsqlCommand($"COPY {tableName} FROM '{filePath}' (DELIMITER '{delimiter}')", conn);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception e)
                    {
                        result = false;
                        transaction.Rollback();
                        throw e;
                    }
                    finally
                    {
                        if (result)
                        {
                            transaction.Commit();
                        }
                        transaction.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                result = false;
            }
            finally
            {
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            return result;
        }
