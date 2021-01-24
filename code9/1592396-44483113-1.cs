    public List<MyWords>  SortWords(bool sortAscending)
    {
        var wordList = conn.Table<MyWords>();
       
        if(sortAscending){
            return wordList.OrderBy(w=>w.ID).ToList();
        }
        else{
            return wordList.OrderByDescending(w => w.ID).ToList();
        }
    }
