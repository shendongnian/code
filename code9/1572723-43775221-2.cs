     private static Query parseQuery(string searchQuery, QueryParser parser)
     {
        Query query;
        try
        {
          query = parser.Parse(searchQuery);
        }
        catch (ParseException e)
        {
          query = null;
        }
        if (query == null)
        {
          string replacedQuery;
          cooked = Regex.Replace(searchQuery, @"\B[A-Z]", m => "" + m.ToString().ToLower());
          cooked = Regex.Replace(cooked, "[^a-zA-Z0-9]+", " ");
          query = parser.Parse(replacedQuery);
        }
        return query;
    }
