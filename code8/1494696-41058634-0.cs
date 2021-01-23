        public void InsertToDatabase(string table, string columns, List<string> values)
        {
            using (SQLiteConnection dbConnection = new SQLiteConnection(conString))
            {
                dbConnection.Open();
                using (SQLiteCommand insertionCommand = new SQLiteCommand(dbConnection))
                {
                    insertionCommand.CommandText = "INSERT INTO " + table + " (" + columns + ") VALUES (";
                    for (int i=0;i<values.Count;i++)
                    {
                        insertionCommand.CommandText += "@val" + i.ToString() + ",";
                        insertionCommand.Parameters.AddWithValue("@val"+i.ToString(), values[i]);
                    }
                    insertionCommand.CommandText = insertionCommand.CommandText.Substring(0, insertionCommand.CommandText.Length - 1);
                    insertionCommand.CommandText+=")";
                    insertionCommand.ExecuteNonQuery();
                }
            }
        }
