        public void Main()
        {
            try
            {
                String Server = Dts.Variables["User::Connection"].Value.ToString();
                String Cube = "TestCube";
                String conn = "Provider=MSOLAP;Data Source=" + Server + ";";
                Server MDXServer = new Server();
                MDXServer.Connect(conn);
                //Add collection to contain partitions to be dropped
                List<Partition> partitions = new List<Partition>();
                foreach (Database db in MDXServer.Databases)
                {
                    foreach (Cube cb in db.Cubes)
                    {
                        if (cb.Name == Cube)
                        {
                            foreach (MeasureGroup mg in cb.MeasureGroups)
                            {
                                foreach (Partition pt in mg.Partitions)
                                {
                                    string PartName = (pt.Name.ToString());
                                    //Create SQL query to reference the parition view and check row count when partition name used in predicate:
                                    string sqlString = "SELECT COUNT(*) FROM [dim].[Partitions] WHERE [Partition] = @pt;";
                                    // Open DB connection:
                                    ConnectionManager cm;
                                    cm = Dts.Connections["Server_Alias"];
                                    SqlConnection connection = (SqlConnection)cm.AcquireConnection(Dts.Transaction);
                                    // Link the query and the connection string together as a command
                                    SqlCommand cmd = new SqlCommand(sqlString, connection);
                                    // Add a value to the parameter in the SQL query
                                    cmd.Parameters.AddWithValue("@pt", PartName);
                                    
                                    // Activate reader to read the resulting data set from the query
                                    SqlDataReader reader = cmd.ExecuteReader();
                                    while (reader.Read()) //while loop performs an action whilst the reader is open
                                    {
                                        // Put the result of query into a string variable in the script task
                                        string rowCount = reader[0].ToString();
                                        //if the partition exists but is not in the database dim.Partitions view, drop from collection.
                                        if (rowCount == "0")
                                        {
                                            partitions.Add(pt);
                                        }
                                    }
                                    //End the read loop
                                    reader.Close();
                                    }
                            }
                        }
                    }
                }
                //Loop through the collection created in the above foreach loop and drop the partitions in it from the server.
                foreach (Partition dropPartition in partitions)
                {
                    XmlaWarningCollection warningColln = new XmlaWarningCollection();
                    dropPartition.Drop(DropOptions.Default, warningColln);
                }
             Dts.TaskResult = (int)ScriptResults.Success;
            }
              catch (Exception ex)
            {
                //catch error and return error to package for logging 
                Dts.Events.FireError(0, "Script task error: ", ex.Message + "\r" + ex.StackTrace, String.Empty, 0);
                Dts.TaskResult = (int)ScriptResults.Failure;  
            }
            
        }
