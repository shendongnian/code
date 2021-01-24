     using (SqlConnection conn = new SqlConnection(cmn.connString))
            {
                conn.Open();
                string query = "select networkid, network from custom_networkList";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int networkid = Convert.ToInt32(reader["networkid"]);
                        string network = reader["network"].ToString();
                        File.Copy(Templatefile, newfile + network + ".sqlite", true);
                        using (SQLiteConnection m_dbConnection = new SQLiteConnection(@"Data Source=" + newfile + network + ".sqlite;Version=3;"))
                        {
                            m_dbConnection.Open();
                            using (SQLiteCommand command = new SQLiteCommand("begin", m_dbConnection))
                            {
                                command.ExecuteNonQuery();
                                insertZone(m_dbConnection);
                                InsertJunctions(m_dbConnection, networkid);
                                InsertHydrant(m_dbConnection, networkid);
                                insertWaterTank(m_dbConnection, networkid);
                                insertPump(m_dbConnection, networkid);
                                InsertReservoir(m_dbConnection, networkid);
                                insertValve(m_dbConnection, networkid);
                                insertPipe(m_dbConnection, networkid);
                                using (command = new SQLiteCommand("end", m_dbConnection))
                                {
                                    command.ExecuteNonQuery();
                                }
                                // m_dbConnection.Close();
                                // command.Dispose();
                            }
                        }
                    }
                }
            }
            GC.WaitForPendingFinalizers();
            GC.Collect();
            if (!Directory.Exists(newfilename))
            {
                // Try to create the directory.
                File.Delete(newfilename);
            }
            ZipFile.CreateFromDirectory(newfile, newfilename, CompressionLevel.Fastest, true);
            Directory.Delete(newfile, true);
            return newfilename2;
