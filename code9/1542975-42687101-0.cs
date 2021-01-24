    public void GetNewMemes(string subReddit, int count)
    {
        SetSelectedSubreddit(subReddit);
        memesAtATime = count;
        subJSON = null;
        var enumerator = GetJSONFromSelectedSubreddit();
        while (enumerator.MoveNext());
    
        enumerator = LoadNewMemes();
        while (enumerator.MoveNext());
    }
