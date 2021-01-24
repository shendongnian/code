    List<object> filtered = new List<object>();
    
    if(myList.Count % 3 != 0)
    {
       return myList.First();
    }
    else
    {
       for(int i = 3; i < myList.Count; i = i +3)
    {
       filterList.Add(myList[i]);
    }
