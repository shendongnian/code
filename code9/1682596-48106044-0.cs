    int winCount = GetWinCount();   // get the value 4 from somewhere, e.g. the database
    int lossCount = GetLostCount(); // get the value 3 from somewhere, e.g. the database
    
    string resultColumnName = "Result";
    string winsColumnName = "Wins";     // we don't actually need this
    string lossesColumnName = "Losses"; // we don't actually need this
    
    // what we want is a string like this:
    // Result='4-3'
    
    string query = "UPDATE ... SET " + resultColumnName + " = '" + winCount + "-" + lossCount + "' WHERE ..."
    
