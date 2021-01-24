        void DBThreadProc(object o)
        {
            SqlConnection con = null;
            SqlCommand com = null;
            try
            {
                con = new System.Data.SqlClient.SqlConnection(/*ConnectionString*/);
                com = new SqlCommand();
                com.Connection = con;
                com.CommandText = PrepareQuery();
                con.Open();
                SqlDataReader reader = com.ExecuteReader();
                int count = 0;
                MemoryStream memStream = memStream1;
                memStreamWriteStatus = 1;
                readyToWriteToMemStream1.WaitOne();
                while (reader.Read())
                {
                    // Populate
                    Customer customer = new Customer();
                    foreach (var column in Columns)
                    {
                        int fieldIndex = reader.GetOrdinal(column);
                        object value = reader.GetValue(fieldIndex);
                        customer[column.Name] = value;
                    }                   
                    // Serialize: I used a custom Serializer 
                    // but BinaryFormatter should be fine
                    DBDataFormatter.Serialize(memStream, customer);
                    count++;
                    if (count == PAGESIZE) // const int PAGESIZE = 10000
                    {
                        switch (memStreamWriteStatus)
                        {
                            case 1: // done writing to stream 1
                                {
                                    memStream1.Position = 0;
                                    readyToSendFromMemStream1.Set();
                                    // write stream 1 is done...waiting for stream 2 
                                    readyToWriteToMemStream2.WaitOne();
                                    memStream = memStream2;
                                    memStream.Position = 0;
                                    memStream.SetLength(0); // Added:To Reset the stream. Else was getting garbage data back
                                    memStreamWriteStatus = 2;
                                    break;
                                }
                            case 2: // done writing to stream 2
                                {
                                    memStream2.Position = 0;
                                    readyToSendFromMemStream2.Set();
                                    // Write on stream 2 is done...waiting for stream 1
                                    readyToWriteToMemStream1.WaitOne();
                                    // done waiting for stream 1 
                                    memStream = memStream1;
                                    memStreamWriteStatus = 1;
                                    memStream.Position = 0;
                                    memStream.SetLength(0); // Added: Reset the stream. Else was getting garbage data back
                                    break;
                                }
                        }
                        count = 0;
                    }
                }
                if (count > 0)
                {
                    switch (memStreamWriteStatus)
                    {
                        case 1: // done writing to stream 1
                            {
                                memStream1.Position = 0;
                                readyToSendFromMemStream1.Set();
                                // END write stream 1 is done...waiting for stream 2 
                                break;
                            }
                        case 2: // done writing to stream 2
                            {
                                memStream2.Position = 0;
                                readyToSendFromMemStream2.Set();
                                // END write stream 2 is done...waiting for stream 1 
                                break;
                            }
                    }
                }
                bDoneWriting = true;
                bCanRead = false;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (com != null)
                {
                    com.Dispose();
                    com = null;
                }
                if (con != null)
                {
                    con.Close();
                    con.Dispose();
                    con = null;
                }
            }
        }
