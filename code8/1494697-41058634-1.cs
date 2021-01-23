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
                        //add in the parameter to the insert command
                        insertionCommand.CommandText += "@val" + i.ToString() + ",";
                    //add the parameter
                        insertionCommand.Parameters.AddWithValue("@val"+i.ToString(), values[i]);
                    }
                    //remove the last comma from the insert command and add a bracket
                    insertionCommand.CommandText = insertionCommand.CommandText.Substring(0, insertionCommand.CommandText.Length - 1);
                    insertionCommand.CommandText+=")";
                    insertionCommand.ExecuteNonQuery();
                }
            }
        }
        //this is the dummy function to show how to populate the list to pass as the values
        public void UseInsert()
        {
            List<string> insertValues = new List<string> { };
            insertValues.Add("Bruce");
            insertValues.Add("Wayne");
            InsertToDatabase("people", "Name,Surname", insertValues);
        }
