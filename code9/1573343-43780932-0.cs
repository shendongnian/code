            using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Constants.FileName + ";Extended Properties=\"Excel 8.0;HDR=NO;IMEX=3;READONLY=FALSE\""))
            {
                // string query = String.Format("INSERT INTO  [DataSet$]({0}) VALUES ({1})",colName, data);
                
                    connection.Open();
                    string commandString = String.Format("UPDATE [DataSet$] SET colName ='{0}' WHERE keyName = '{1}'",@data,@keyName);
                    OleDbCommand cmd = new OleDbCommand(commandString, connection);
                cmd.Parameters.AddWithValue("@data", data);
                cmd.Parameters.AddWithValue("@keyName", keyName);
                connection.Close();
                    connection.Dispose();
                }
            }
        }
