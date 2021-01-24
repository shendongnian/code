    class Program
        {
            static void Main(string[] args)
            {
                decimal one = 1.4M; decimal two = 3.4M; decimal sum = 0;
                sum = one + two;
                Int32 final = (Int32)(sum);
                Int32 roundfinal = (Int32)(Math.Round(sum));
                Console.WriteLine("final is "+ final);
                Console.WriteLine("roundfinal is " + roundfinal);
                Console.ReadLine();
    
            }
        }
