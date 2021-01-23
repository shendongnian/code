                System.IO.StreamReader SourceFile =
                new System.IO.StreamReader(SourceFolder+SourceFileName);
                string line = "";
                Int32 counter = 0;
                SQLConnection.Open();
                while ((line = SourceFile.ReadLine()) != null)
                {
                    //skip the header row
                    if (counter > 0)
                    {
                        //prepare insert query
                        string query = "Insert into " + TableName +
                               " Values ('" + line.Replace(filedelimiter, "','") + "')";
                        `enter code here`//execute sqlcommand to insert record
                        `enter code here`SqlCommand myCommand = new SqlCommand(query, SQLConnection);
                        myCommand.ExecuteNonQuery();
                    }
                    counter++;
                }
                SourceFile.Close();
                SQLConnection.Close();
                //Move the file to Archive folder
                File.Move(SourceFolder+SourceFileName, ArchiveFodler + SourceFileName);              
            }
            catch(IOException Exception)
            {
                Console.Write(Exception);
            }
            }
