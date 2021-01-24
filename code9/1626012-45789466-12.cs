    class ChangeCalculator
    {
      public int Money { get; set; }
      public int Bill { get; set; }
      public ChangeCalculator()
      {
         Money = 0;
         Bill = 0;
      }
      public void ChangeCalculator(int money, int bill)
      {
         Money = money;
         Bill = bill;
      }
      public int Calculate()
      {
        return Money - Bill;
      }
    }
