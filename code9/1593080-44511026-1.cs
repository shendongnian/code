    IQueryable<Aspect> query = db.Aspects.AsQueryable();
    
      //note, if AllWords is empty, query is not modified.
    foreach(SearchAllWord x in AllWords)
    {
      //important, lambda should capture local variable instead of loop variable.
      string word = x.Word; 
      query = query.Where(aspect => aspect.Value.Contains(word);
    }
    
    foreach(SearchNotWord x in NotWords)
    {
      string word = x.Word;
      query = query.Where(aspect => !aspect.Value.Contains(word);
    }
    
    if (AnyWords.Any()) //haha!
    {
      List<string> words = AnyWords.Select(x => x.Value).ToList();
      query =
        from aspect in query
        from word in words  //does this work in EF?
        where aspect.Value.Contains(word)
        group by aspect into g
        select g.Key;
    }
