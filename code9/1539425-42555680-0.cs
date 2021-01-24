    public bool SearchNotes(NoteModel CurrentNote, string sSearch)
        {
            //check the open connection
            if (ConnectData.OpenConnection() == true)
            {
                try
                {
                    string SQLSearch = "select note_id, date, time, note from note where date like '%" + sSearch + "%' or time like '%" + sSearch + "%' or note like '%" + sSearch + "%' group by note_id, date, time, note";
                    //get the phone types for lookups
                    SqlCommand cmdSearchNotes = new SqlCommand(SQLSearch, ConnectData.connection);
                    SqlDataReader drSearchResults = cmdSearchNotes.ExecuteReader();
                    
                    // CHANGE IS HERE !!!!!!!!!!!!!!!!
                    var list = new List<NoteModel.SearchResult>();
                    while (drSearchResults.Read())
                    {
                        CurrentNote.SearchResults.Add(new NoteModel.SearchResult()
                        {
                            NoteID = (int)drSearchResults["note_id"],
                            Date = drSearchResults["date"].ToString(),
                            Time = drSearchResults["time"].ToString(),
                            Note = (string)drSearchResults["note"]
                        });
                    }
                    // CHANGE IS HERE !!!!!!!!!!!!!!!! 
                    CurrentNote.SearchResults = list;
                    drSearchResults.Dispose();
                    cmdSearchNotes.Dispose();
                    //close Connection
                    ConnectData.CloseConnection();
                    return true;
                }
                catch (SqlException ex)
                {
                    return false;
                    throw new ApplicationException("Something went wrong with fetching the note search results: ", ex);
                }
            }
            //connection failed
            else
            {
                return false;
            }
        }
        
