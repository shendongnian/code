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
          replacedQuery = Regex.Replace(searchQuery, @"\B[A-Z]", m => "" + m.ToString().ToLower());
          cooked = cooked.TrimEnd(new Char[] { ' ', '*', '.' ,'+','-','/'});
          query = parser.Parse(replacedQuery);
        }
        return query;
    }
