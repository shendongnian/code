    class MyTotalList {
      private int total;
      private List<MyObject> amounts;
      public MyTotalList() {
        total = 0;
        amounts = new List<MyObject>();
      }
      public int ListCount {
        get { return amounts.Count; }
      }
      public IReadOnlyCollection<MyObject> Items {
        get { return amounts.AsReadOnly(); }
      }
      public int Total {
        get { return total; }
      }
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
