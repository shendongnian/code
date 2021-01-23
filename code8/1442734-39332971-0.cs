    class Program
    {
      public decimal[,] arrayObj = new decimal[5, 5];
      public void Main(string[] args)
      {
        for (int i = 0; i < 4; i++)
         {
           arrayObj[i][i] = 1;
           arrayObj[i+1] = 1;            
        }
    }
