    class pointOnBorder{
       static void Main(){
          var x1 = decimal.Parse(Console.ReadLine());
          var y1 = decimal.Parse(Console.ReadLine());
    
          var x2 = decimal.Parse(Console.ReadLine());
          var y2 = decimal.Parse(Console.ReadLine());
    
          var x = decimal.Parse(Console.ReadLine());
          var y = decimal.Parse(Console.ReadLine());
    
          if (x1 < x2 && y1 < y2)
          {
             if (x == x1 || x == x2)
             {
                if (y >= y1 && y <= y2)
                {
                   Console.WriteLine("Border");
                }
                else
                {
                   Console.Write("Inside  / Outside");
                }
             }
             else if (y == y1 || y == y2)
             {
                if (x >= x1 && x <= x2)
                {
                   Console.WriteLine("Border");
                }
                else
                {
                   Console.Write("Inside  / Outside");
                }
             }
             else
             {
                Console.Write("Inside  / Outside");
             }
          }
          else{
             Console.Write("Bad rectangle specification.");
          }
       }
    }
