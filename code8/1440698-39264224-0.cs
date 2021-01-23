    void main()
    {
        PrintTree(listOfCategorys);
    }
    
    void PrintTree(IEnumerable<CMBCategory> list)
    {
      
      foreach(var item in list)
      {
         PrintTree(item.children);
         DoSomehtingWithTheObject(item); // ie. print it , or what ever you want 
    
      }
    }
