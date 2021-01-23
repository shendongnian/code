            try
            {
                long personID = 0;
                using (SQLiteConnection sqlconnection = new SQLiteConnection("Data Source=" + DbPath + ";Version=3;"))
                {
                    sqlconnection.Open();
                    SQLiteCommand PersonCommand = sqlconnection.CreateCommand();
                    SQLiteParameter personParam = new SQLiteParameter();
                    PersonCommand.CommandText = "INSERT INTO Person('Name') VALUES(?)";
                    PersonCommand.Parameters.Add(personParam);
                    SQLiteCommand FileCommand = sqlconnection.CreateCommand();
                    SQLiteParameter FileParam1 = new SQLiteParameter("@filename");
                    SQLiteParameter FileParam2 = new SQLiteParameter("@filepath");
                    SQLiteParameter FileParam3 = new SQLiteParameter("@personid");
                    FileCommand.CommandText = "INSERT INTO file(FileName,FilePath,PersonID) VALUES(@filename,@filepath,@personid)";
                    FileCommand.Parameters.Add(FileParam1);
                    FileCommand.Parameters.Add(FileParam2);
                    FileCommand.Parameters.Add(FileParam3);
                    using (SQLiteTransaction _SQLiteTransaction = sqlconnection.BeginTransaction())
                    {
                        for (int i = 0; i < persons.Count; i++)
                        {
                            personParam.Value = persons[i].Name;
                            PersonCommand.ExecuteNonQuery();
                            personID = sqlconnection.LastInsertRowId;
    
                            foreach (var item in Files.Where(f => f.PersonID == personID))
                            {
                                FileParam1.Value = item.FileName;
                                FileParam2.Value = item.FilePath;
                                FileParam3.Value = item.PersonID;
                                FileCommand.ExecuteNonQuery();
                            }
                        }
                        _SQLiteTransaction.Commit();
                        form.Progress();
                    }
                    sqlconnection.Close();
                }
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
                throw;
            }
