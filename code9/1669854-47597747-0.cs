        static void Main(string[] args)
        {
            string someText;
            using (var connection = new SqlConnection("..."))
            { // autodisposing if no longer needed
                using (var command = new SqlCommand("SELECT * FROM checkout"))
                { // autodisposing ifnolonger needed
                    var msg = new List<string>(); // collect msg to avoid several updates to label
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        { // if rows present, read one by one until done
                            while(reader.NextResult())
                            { // process one row 
                                var movieId = Convert.ToInt32(reader["MovieId"]);
                                var subId = Convert.ToInt32(reader["SubscriberID"]);
                                var dueDate = Convert.ToDateTime(reader["DueDate"]);
                                if (DateTime.Now > dueDate)
                                    msg.Add(SendLateMail(subId));
                            }
                            // make label text, set label afterwards with it
                            someText = string.Join("\n", msg); 
                        }
                        else
                        {
                            // no rows found, set label text
                            someText = "No movies due.";
                        }
                    }                 
                }
            } 
        }
        static string SendLateMail(int subId)
        {
            // send mail & create text to accumulate for label
            return $"Due Email send to {subId}";
        }
