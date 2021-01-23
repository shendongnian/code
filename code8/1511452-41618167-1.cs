    class MyTotalList {
      private int total;
      private List<MyObject> amounts;
      public MyTotalList() {
        total = 0;
        amounts = new List<MyObject>();
      }
      public List<MyObject> Items {
        get { return amounts; }
      }
      public int Total {
        get { return total; }
      }
      // if you eliminate the id and do not care about duplicates
      // then you can remove the check for duplicates (if contains...)
      public void Add(MyObject other) {
        if (other != null) {
          if (!(amounts.Contains(other))) {
            total += other.amount;
            amounts.Add(other);
          }
          else {
            Console.WriteLine("Duplicate id's not allowed!");
          }
        }
      }
      // if you never want to remove items OR you do not care about duplicates
      // then you can remove this method
      public void Remove(MyObject other) {
        if (amounts.Contains(other)) {
          total -= amounts[amounts.IndexOf(other)].amount;
          amounts.Remove(other);
        }
        else {
          Console.WriteLine("Item to remove not found!");
        }
      }
    }
