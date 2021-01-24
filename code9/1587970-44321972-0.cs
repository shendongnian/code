    List<string> newList = new List<string>();
    int index = 0;
    string newValue = string.Empty;
    foreach (var item in arraylist)
    {
       newValue += item;
       index ++;
       if(index == 2)
       {
          newList.Add(newValue);
          index == 0;
       }
    }
