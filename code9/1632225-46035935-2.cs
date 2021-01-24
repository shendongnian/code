    public Dictionary<string,bool> myDic = new Dictionary<string,bool>(5);      
    myDic.Add("test1", false);
    myDic.Add("test2", true);
    myDic.Add("test3", false);
    myDic.Add("test4", true);
    myDic.Add("test5", true);
    string currentKey;
    KeyValuePair<string,bool> res;
    if (currentKey==null)
    {
        res=myDic.Where(x => x.Value).FirstOrDefault();
    }
    else
    {
        res=myDic.Where(x => x.Value).SkipWhile(x => x.Key !=             
              currentKey).Skip(1).FirstOrDefault();
    }
    if (res.Key!=null)
    {
         currentKey=res.Key;
         Console.WriteLine(currentKey);
    }
    else
    {
        Console.WriteLine("Result is null");
    } 
   
