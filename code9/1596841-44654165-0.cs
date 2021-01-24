     static void ExcelToCSVCoversion(string sourceFile, string worksheetName,
           string targetFile)
        {
            string connectionString = @"Provider =Microsoft.ACE.OLEDB.12.0;Data Source=" + sourceFile
                + @";Extended Properties=""Excel 12.0 Xml;HDR=YES""";
            OleDbConnection connection = null;
            StreamWriter writer = null;
            OleDbCommand command = null;
            OleDbDataAdapter dataAdapter = null;
            try
            {
                // Represents an open connection to a data source. 
                connection = new OleDbConnection(connectionString);
                connection.Open();
                // Represents a SQL statement or stored procedure to execute  
                // against a data source. 
                command = new OleDbCommand("SELECT * FROM [" + worksheetName + "$]",
                                            connection);
                // Specifies how a command string is interpreted. 
                command.CommandType = CommandType.Text;
                // Implements a TextWriter for writing characters to the output stream 
                // in a particular encoding. 
                writer = new StreamWriter(targetFile);
                // Represents a set of data commands and a database connection that are  
                // used to fill the DataSet and update the data source. 
                dataAdapter = new OleDbDataAdapter(command);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                var emptyRows =
                    dataTable.Select()
                        .Where(
                            row =>
                                dataTable.Columns.Cast<DataColumn>()
                                    .All(column => string.IsNullOrEmpty(row[column].ToString()))).ToArray();
                emptyRows.ForEach(x => x.Delete());
                var emptyColumns =
                    dataTable.Columns.Cast<DataColumn>()
                        .Where(column => dataTable.Select().All(row => string.IsNullOrEmpty(row[column].ToString())))
                        .ToArray();
                emptyColumns.ForEach(column => dataTable.Columns.Remove(column));
                dataTable.AcceptChanges();
                
                for (int row = 0; row < dataTable.Rows.Count; row++)
                {
                    string rowString = "";
                    for (int column = 0; column < dataTable.Columns.Count; column++)
                    {
                        rowString += "\"" + dataTable.Rows[row][column].ToString() + "\",";
                    }
                    writer.WriteLine(rowString);
                }
                Console.WriteLine();
                Console.WriteLine("The excel file " + sourceFile + " has been converted " +
                                  "into " + targetFile + " (CSV format).");
                Console.WriteLine();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.ToString());
                Console.ReadLine();
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
                connection.Dispose();
                command.Dispose();
                dataAdapter.Dispose();
                writer.Close();
                writer.Dispose();
            }
        }
