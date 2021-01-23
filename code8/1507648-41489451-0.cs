    private readonly object _padLock = new object();
    public void CallingMethod() {
       Task.Factory.StartNew(() => { MyMethod(); })
    }
    public void MyMethod() {
       lock (_padLock)
       {
          //The myDict object needs to be shared by all threads.
          Dictionary<string, List<MyObject>> myDict = new Dictionary<string, List<MyObject>>();
          //GetKeyValue() may return the same key multiple times
          foreach(var kv in GetKeyValue()) { 
            if(myDict.ContainsKey(kv.Key) { myDict[kv.Key].Add(kv.Value); }
            else { myDict.Add(kv.Key, kv.Value); }
            RunSubsetSum(kv.Key, myDict);
          }
       }
    }
    //Resource intensive method
    public void RunSubsetSum(string key, Dictionary<string, List<MyObject>> myDict)  { 
        //Lock on key so that no two threads run for the same key
            foreach(var valueToRemove in GetRemovableObjs()) 
                myDict[kv.Key].Remove(valueToRemove);
    }
