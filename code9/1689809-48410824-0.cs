            try
            {
                var connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\MyLearn\ExcelWorkBook.xls;Extended Properties=Excel 8.0";
                
                var sqlText = "CREATE TABLE TimeData ([HH] INT, [MM] INT,[AM / PM] VARCHAR(10))";
                using (var excelConnection = new OleDbConnection(connectionString))
                {
                    object HHValue = TimeInHH.Text;
                    object MMValue = TimeInMM.Text;
                    object AMPMValue = Combo1AMPM.Text;
                    // Executing this command will create the worksheet inside of the workbook
                    // the table name will be the new worksheet name
                    using (var command = new OleDbCommand(sqlText, excelConnection))
                    {
                        if (excelConnection.State != ConnectionState.Open)
                        {
                            excelConnection.Open();
                            //check if table already exists.
                            var exists = excelConnection.GetSchema("Tables", new string[4] { null, null, "TimeData", "TABLE" }).Rows.Count > 0;
                            if(!exists)
                               command.ExecuteNonQuery();
                        }
                    }
                    // Add (insert) data to the worksheet
                    var commandText = $"Insert Into TimeData ([HH], [MM], [AM / PM]) Values (@PropertyOne, @PropertyTwo, @PropertyThree)";
                    using (var command = new OleDbCommand(commandText, excelConnection))
                    {
                        // We need to allow for nulls just like we would with
                        // sql, if your data is null a DBNull.Value should be used
                        // instead of null 
                        command.Parameters.AddWithValue("@PropertyOne", HHValue ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PropertyTwo", MMValue ?? DBNull.Value);
                        command.Parameters.AddWithValue("@PropertyThree", AMPMValue ?? DBNull.Value);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
