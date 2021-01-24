    static void Main(string[] args)
        {
            Console.WriteLine("Insert PassWord.");
            string passWord1 = Convert.ToString(Console.ReadLine());
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Confirm PassWord.");
            string passWord2 = Convert.ToString(Console.ReadLine());
            if (passWord1.Equals(passWord2))
            {
                Console.WriteLine("PassWords Match");
            }
            else
            {
                Console.WriteLine("Error: PassWords do not Match");
            }
            Console.WriteLine("Press Enter To Continue");
            Console.ReadKey();
        }
