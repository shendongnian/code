    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("what is num?");
            int num = int.Parse(Console.ReadLine());
            downnums(num);
        }
    
        public static void downnums(int num)
        {
            if (num == 0)
            Console.WriteLine("that all");
            else
            {
                downnums(num-1);
            }
    
           }
    
        }
