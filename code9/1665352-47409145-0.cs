    foreach(var item in mainList)
    {
      if(item is System.Collections.IEnumerable)
      {
            foreach(var obj in ((System.Collections.IEnumerable)item))
            {
                Console.WriteLine(obj);
            }
      }
    }
