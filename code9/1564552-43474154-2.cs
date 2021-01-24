    //mock of your list collection
      List<DateTime> dates = new List<DateTime>()
      {
          {DateTime.Now},
          {DateTime.Now.AddSeconds(8)},
          {DateTime.Now.AddSeconds(18)},
          {DateTime.Now.AddSeconds(28)},
          {DateTime.Now.AddSeconds(30)},
       };
    
       //tempoary store the previous 3 dates
       List<DateTime> dates2 = new List<DateTime>();
    
       foreach (var item in dates)
       {
           dates2.Add(item);
           if (dates2.Count > 2)
           {
               //Check if either dates2[0] & dates2[1] and dates2[1] and dates[2] are 7 seconds apart
               if (dates2.Zip(dates2.Skip(1), (x, y) => y.Subtract(x))
                   .Any(x => x.TotalSeconds < 7))
               {
                   Console.WriteLine("OK");
               }
              //remove the first element so only 3 dates in the temporary list
              dates2.RemoveAt(0);
           }
    }
