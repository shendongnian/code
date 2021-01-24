    List<string> lstColumnName = new List<string>();
                    string strPath = System.IO.Directory.GetCurrentDirectory();
                    try
                    {
                        Cluster cassandraCluster = Cluster.Builder().AddContactPoint(strIpAddress).Build();
                        ISession session = cassandraCluster.Connect(strKeyspace);
                        string strCqlRequest = "SELECT * FROM" + " " + strTable;
                        RowSet rs = session.Execute(strCqlRequest);
        
        
                        using (var w = new StreamWriter(strPathToSave))
                        {
                            
                            //get table columns with types 
                            TableMetadata t = cassandraCluster.Metadata.GetTable(strKeyspace,strTable);
                            TableColumn[] arrcol = t.TableColumns;
        
                            foreach (var strCol in arrcol)
                            {
                                lstColumnName.Add(strCol.Name);
        
                            }
                            IDictionary<string,TableColumn> dic =t.ColumnsByName;
        
                            //Add column liste to the file
                            var strColumnLine = String.Join(",", lstColumnName.ToArray());
                            w.WriteLine(strColumnLine);
                            //Iterate through the RowSet and add rows to the file
                            foreach (Row row in rs)
                            {
                                List<string> values = new List<string>();
                                IEnumerator<Object> colEnumerator = row.GetEnumerator();
        
                                while (colEnumerator.MoveNext())
                                {
                                    values.Add(colEnumerator.Current.ToString());
                                }
                                var line = String.Join(",", values.ToArray());
                                w.WriteLine(line);
                                w.Flush();
        
                            }
        
                        }
