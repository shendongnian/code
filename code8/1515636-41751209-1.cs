    struct Pair
    {
       public int x;
       public int y;
    }
    
    public class Test
    {
       public static void Main()
       {
          Pair dummyInt = new Pair();
          List<Pair> test = new List<Pair>();
          for (int i = 0; i < 100; i++)
          {
             dummyInt.x = i;
             for (int j = 0; j < 5; j++)
             {
                dummyInt.y = j;
                test.Add(dummyInt);
             }
          }
    
          foreach (Pair value in test)
          {
             Console.WriteLine("({0},{1})", value.x, value.y);
          }
       }
    }
