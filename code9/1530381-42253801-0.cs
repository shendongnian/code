    public List<WordEntry> SelectWhere(Func<WordEntry, bool> predicate)
    {
        return WordDataBase.Where(predicate);
    } 
    public List<CharacterEntry> SelectWhere(Func<CharacterEntry, bool> predicate)
    {
        return CharacterDataBase.Where(predicate);
    }
