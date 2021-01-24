    public static double MatchDouble(string haystack, string needle, double weight )
    {
        return haystack.Contains( needle ) ? weight : 0;
    }
<!---->
    var resultsViaInt = accounts
        .OrderBy( 
                  acct => MatchDouble( acct.UserName, somequerytext, 2.0 ) +
                          MatchDouble( acct.UserDescription, somequerytext, 1.0 )  
                )
        .ToList();
