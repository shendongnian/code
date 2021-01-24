    if (!string.IsNullOrEmpty(options.PhraseNum))
    {
        int phraseNum;
        if (int.TryParse(options.PhraseNum, out phraseNum))
        {
            query = query.Where(w => w.PhraseNum == phraseNum);
        }
    }
