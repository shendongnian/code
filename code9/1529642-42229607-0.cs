    try
                {
                    using (OleDbConnection myConnection = new OleDbConnection())//make use of the using statement 
                    {
                        myConnection.ConnectionString = myConnectionString;
                        myConnection.Open();//Open your connection
                        OleDbCommand cmdNotReturned = myConnection.CreateCommand();//Create a command 
                        cmdNotReturned.CommandText = "someQuery";
                        OleDbDataReader readerNotReturned = cmdNotReturned.ExecuteReader(CommandBehavior.CloseConnection);
                            // close conn after complete
                        // Load the result into a DataTable
                        if (readerNotReturned != null) someDataTable.Load(readerNotReturned);
                   }
                }
