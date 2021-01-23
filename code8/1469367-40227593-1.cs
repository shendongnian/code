    public class Program
    {
        public static void Main(string[] args)
        {
            int sum = 0;
            int count = 0;
            int num = 0;
    
            Console.WriteLine("Please enter all the numbers you would like to add. When finished, enter -1");
    
            do 
            {
                string buffer = Console.ReadLine();
     
    			if (Int32.TryParse(buffer, out num) && num != -1)
                {
     			    sum += num;
                    count++;
                    Console.WriteLine(sum);
                }
            }
            while (num != -1);
        }
    }
