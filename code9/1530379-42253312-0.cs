    public List<Entry> SelectWhere<T>(System.Func<T, bool> predicate) where T : Entry
    {
        if (typeof(T) == typeof(WordEntry))
            return WordDataBase
                .Where((Func<WordEntry, bool>) predicate)
                .ToList<Entry>();
        else if (typeof(T) == typeof(CharacterEntry))
            return CharacterDataBase
                .Where((Func<CharacterEntry, bool>) predicate)
                .ToList<Entry>();
        else
            return null;
    }
