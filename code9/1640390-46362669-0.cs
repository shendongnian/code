    using (SqlCommand command = new SqlCommand())
            {
                command.Connection = openCon;
                command.CommandType = CommandType.Text;
                command.CommandText = "update logRecords set totalHours = DATEDIFF(HOUR,@timeIn,@timeOut)";
                try
                {
                    openCon.Open();
                    command.Parameters.AddWithValue("@timeIN", timeIn);
                    command.Parameters.AddWithValue("@timeOut", timeOut);
                    int recordsAffected = command.ExecuteNonQuery();
                    MessageBox.Show("Records affected: " + recordsAffected);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    openCon.Close();
                    GetLogData();
                }
            }
