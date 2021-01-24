    static void Main(string[] args)
    {
        string someText;
        using (var connection = new SqlConnection("..."))
        { 
            // autodisposing if no longer needed
            using (var command = new SqlCommand("SELECT * FROM checkout"))
            { 
                var msg = new List<string>(); // collects msg to avoid several updates to label
                // autodisposing ifnolonger needed
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    { 
                        // if rows present, read one by one until done
                        while(reader.NextResult())
                        { 
                            // process one row 
                            var movieId = Convert.ToInt32(reader["MovieId"]);
                            var subId = Convert.ToInt32(reader["SubscriberID"]);
                            var dueDate = Convert.ToDateTime(reader["DueDate"]);
                         
                            // check due
                            if (DateTime.Now > dueDate)
                                msg.Add(SendLateMail(subId)); // send mail and store message
                        }
                        // make label text by joining all msg with newlines
                        someText = string.Join("\n", msg); 
                    }
                    else
                    {
                        // no rows found, set label text
                        someText = "No movies due.";
                    }
                    // TODO: set your labels .Text
                }                 
            }
        } 
    }
    static string SendLateMail(int subId)
    {
        // Todo: send mail 
        // create text to accumulate for label
        return $"Due Email send to {subId}";
    }
