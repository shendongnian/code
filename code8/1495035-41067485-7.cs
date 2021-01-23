    for (int i = 0; i < list1.Count; i++)
    {
       bool exists = false;
       for (int j = 0; j < list2.Count; j++)
          if (i == list2[j]) 
          {
             exists = true;
             break;
          }
       if (!exists) newList.Add(list1[i]);
    }
