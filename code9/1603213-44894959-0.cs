    using System;
    
    namespace ArrayandStringPractice
    {
      class MainClass
      {
        public static void Main(string[] args)
        {
          int[] a = new int[10];
    
          for (int i = 0; i < 10; i++)
            for (int j = 0; j < 10; j++)
            {
              {
                a[i] = i * j;
                //Console.WriteLine(a[i]);
              }
            }
    
          foreach (int i in a)
          {
            Console.WriteLine(i);
          }
        }
      }
    }
