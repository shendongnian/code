    public List<ISynchronizable> list = new List<ISynchronizable>();
    list.AddRange(fixationList);
    list.AddRange(textChangeList);
    resultList = list.OrderBy(e => e.GetTicks()).ToList();
    
  
