    foreach (LdapResult r in ldapResults)
    {
        finalResults.Add(new SearchResult(r));
    }
    
    foreach (DatabaseResult r in databaseResults)
    {
        SearchResult sr = new SearchResult(r);
        int i = finalResults.IndexOf(sr);
        if (i > -1)
        {
            finalResults[i].Merge(sr);
        }
        else
        {
            finalResults.Add(sr);
        }
    }
