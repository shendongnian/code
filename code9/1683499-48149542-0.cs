    IEnumerable<Dto> dtos = concurrentDictionary.Select(p => p.Value);
    
    ArrayList arrayList = new ArrayList();
    foreach (object obj in dtos)
    {
        //is it thread safe accessing the Dto like this and adding them to new arraylist?
        arrayList.Add(obj);
    }
