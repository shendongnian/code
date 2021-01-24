    List<object> filtered = new List<object>();
    List<object> reversedList = myList.Reverse();
    if(reversedList.Count % 3 != 0)
    {
       return reversedList.Last();
    }
    else
    {
       for(int i = 3; i < reversedList.Count; i = i +3)
    {
       filterList.Add(reversedList[i]);
    }
    if(!filterList.Contains(reversedList.Last())
    {
       filterList.Add(reversedList.Last());
    }
