    class ChangeCalculator
    {
      public int Money { get; private set; }
      public int Bill { get; private set; }
      public ChangeCalculator()
      {
         Money = 0;
         Bill = 0;
      }
      public void Change(int money, int bill)
      {
         Money = money;
         Bill = bill;
      }
      public int Calculate()
      {
        return Money - Bill;
      }
    }
