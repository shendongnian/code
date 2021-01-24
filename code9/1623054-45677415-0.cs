    public DataTable GetTableData(string StrSQL)
        {
            DataTable dataTable = new DataTable();
            MySqlCommand mySqlCommand = null;
            MySqlDataReader mySqlDataReader = null;
            try
            {
                    mySqlCommand = new MySqlCommand(StrSQL, Connection);                    
                    mySqlDataReader = mySqlCommand.ExecuteReader();
                    dataTable.TableName = "mydata";
                    dataTable.Load(mySqlDataReader);                    
               
            }
            finally
            {
                if (mySqlDataReader != null)
                {
                    if (!mySqlDataReader.IsClosed)
                    {
                        mySqlDataReader.Close();
                    }
                }
            }
            return dataTable;
        }
