    string ECJoblink_previous = null;
    LookAheadRunInfo lookaheadRunInfo = null;
    while (rdr.Read())
    {
        if (ECJoblink_previous != rdr.GetString(0))  //A new set of rows is starting
        {
            if (lookaheadRunInfo != null)
            {
                lookaheadRunsInfo.Add(lookaheadRunInfo); //Save the old group, if it exists
            }
            lookaheadRunInfo = new LookAheadRunInfo     //Start a new group and initialize it
            {
                ECJobLink = rdr.GetString(0),
                gerrits = new List<string>(),
                UserSubmitted = rdr.GetString(2),
                SubmittedTime = rdr.GetString(3).ToString(),
                RunStatus = "null",
                ElapsedTime = (DateTime.UtcNow-rdr.GetDateTime(3)).ToString()
            }
        }
        lookahead.gerrits.Add(rdr.GetString(1));   //Add current row
        ECJoblink_previous = rdr.GetString(0);     //Keep track of column 0 for next iteration
    }
    if (lookaheadRunInfo != null)
    {
        lookaheadRunsInfo.Add(lookaheadRunInfo); //Save the last group, if there is one
    }
