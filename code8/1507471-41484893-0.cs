            private void TakeBackup()
            {
                var conn = new SqlConnection("Data Source=" + Server + ";Initial Catalog=" + Database + ";User Id=" + Username + ";Password=" + Password + ";");
                try
                {
                    conn.Open();
                    SqlCommand command = conn.CreateCommand();
                    command.CommandText = "RESTORE DATABASE AdventureWorks FROM DISK = 'C:\AdventureWorks.BAK' WITH REPLACE GO";
                    command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    conn.Dispose();
                    conn.Close();
                }
            }
