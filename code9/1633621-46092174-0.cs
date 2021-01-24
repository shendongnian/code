    int ARRAY_SIZE= 100000;
    Dictionary<string, object> pArr = new Dictionary<string, object>()
    
    public void Put(string key, string object)
    {
       if(pArr.ContainsKey(key))
          pArr[key] = value;
       else 
       {
          if(pArr.Count() >= ARRAY_SIZE)
             throw new Exception("All slots full");
    
          pArr.Add(key, value)
       }
    }
