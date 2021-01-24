     public static int downnums(int num)
        {
           if (num == 0)
            {
              Console.WriteLine("that all");
            }
          else
            {
              Console.WriteLine(downnums(num-1));
            }
         return num;
    
         }
