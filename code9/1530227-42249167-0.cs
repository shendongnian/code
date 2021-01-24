    static void Main(string[] args)
    {
                int m, count = 0;
                Console.WriteLine("Enter the Limit : ");
                m = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter the Numbers :");
                
                for (int i = 0; i < m; i++)
                {
                  if(Console.ReadLine() == "1")
                     count++;
                }
    
                Console.WriteLine("Number of 1's in the Entered Number : "+count);
    
                Console.ReadLine();
    }
