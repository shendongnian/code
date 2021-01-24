      static void Main(string[] args)
        {
          
 
            try
               {
                int i = 0;
                int number;
                int input=0;
                Console.WriteLine("Enter target number ");
                number =   int.Parse(Console.ReadLine());
                while (input != number && input < number)
                {
                    Console.WriteLine($"Enter number  {i+1}");
                    input += int.Parse(Console.ReadLine());
                    i++;
                }
                Console.WriteLine($"It took {i} number to make the sum {number}");
              }
              catch (Exception e)
              {
                      
              }
          
            Console.ReadLine();
        }
