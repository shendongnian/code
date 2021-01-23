    Names name1 = new Names() { ID = 1, User = "John" };
    Names name2 = new Names() { ID = 2, User = "Mike" };
    Names name3 = new Names() { ID = 3, User = "Ben" };
    List<Names> names = new List<Names>();
    names.Add(name1);
    names.Add(name2);
    names.Add(name3);
    foreach(var item in names)
    {
      if(item.ID == 2)
      {
         string strName = item.Name;
         break;
      }
    }
