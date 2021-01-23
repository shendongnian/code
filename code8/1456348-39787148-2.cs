      class Program
      {
        static IEnumerable<int> EnumNearestSums(IList<int> list, int z)
        {
          var target = (int)(list.Sum() / (double)z + 0.5);
          var index = 0;
    
          for (int i = 0; i < z; i++)
          {
            var sum = 0;
            for (int j = index; j < list.Count; j++)
            {
              index++;
              var tmp = sum + list[j];
              if (tmp > target)
              {
                if (Math.Abs(target - sum) < Math.Abs(target - tmp))
                {
                  index--;
                }
                else
                {
                  sum = tmp;
                }
                break;
              }
              else
              {
                sum = tmp;
              }
            }
            yield return sum;
          }
        }
    
        static void Main(string[] args)
        {
          var list = new[] { 32183, 15883, 26917, 25459, 22757, 25236, 1657 };
          var z = 3;
    
          foreach (var num in EnumNearestSums(list, z))
          {
            Console.WriteLine(num);
          }
    
          Console.ReadLine();
        }
      }
