    List<T> list3=new List<T>
    foreach(var item in list1)
    {
       if(list2.Contains(item))
       {
          list3.Add(list2.First(x=>x.id==item.id)) //considering id is key
       }
       else
       {
          list3.Add(item);
       }
    }
