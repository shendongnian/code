    public List<MyWords>  SortWords()
    {
       var wordList = conn.Table<MyWords>();
       return wordList.OrderByDescending(w => w.ID).ToList();
    }
