                    //Initiate database connection 
                    string databaseFile = DatabaseFolderPath + @"\database.sqlite";
                    using (var conn = new SQLiteConnection(
                        "Data Source=" + databaseFile + ";"))
                    {
                        conn.Open();
                        using (var cmd = new SQLiteCommand(conn))
                        {
                            using (var transaction = conn.BeginTransaction())
                            {
                                
                                #region foreach row
                                foreach (DataRow rowData in Datatable.Rows)
                                {
                                    string number = Convert.ToString(rowData["number"]);
                                    //Check in List and/or update item
                                    var matchingNumber = _SQlData.FirstOrDefault(_stoItem => (_stoItem.Number == number));
                                       if (matchingNumber != null)
                                       {
                                          //Number found in List so update count using +1
                                          int getLinesCount = matchingNumber.Count + 1;
                                           //Update with new amount
                                           matchingNumber.Count = getLinesCount;
                                       }else{
                                       
                                          //Create New Item in String based of Number
                                       }
                                }
                                #endregion foreach row
                                #region foreach item in the List
                                foreach (var _item in _SQLData)
                                 {
                                    cmd.CommandText = "INSERT INTO dbTable (number,count) values ('" + _item.Number + "','" + _item.Count + "')";
                                    cmd.ExecuteNonQuery();
                                    
                                }
                                #endregion foreach item in the List
                             transaction.Commit();
                            }
                        }
