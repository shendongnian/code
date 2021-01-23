    var phrasesCount = await db.Phrases.CountAsync();
    return new List<object>
    {
        new 
        {
            Col1 = phrasesCount
        }
    };
