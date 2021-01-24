    namespace CsPerfs
    {
      using System;
      using System.Collections.Generic;
      using System.Linq;
        public static class Perfs
        {
          static int Remainder(int num)
          {
              return num % 2;
          }
          static int SumOfremainders(IEnumerable<int> list)
          {
              var sum = 0;
              foreach (var num in list)
              {
                  sum += Remainder(num);
              }
              return sum;
          }
      
          public static Func<int> CsOpTest (int count)
          {
            return () => SumOfremainders (Enumerable.Range(1, count));
          }
          public static Func<int> CsImperativeTest (int count)
          {
            return () =>
              {
                var sum = 0;
                for (var n = 0; n < count; ++n)
                {
                  sum += n % 2;
                }
                return sum;
              };
          }
          public static Func<int> CsLinqTest (int count)
          {
            return () => Enumerable.Range (0, count).Select (n => n % 2).Sum ();
          }
        }
    }
