    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter numbers");
            decimal argument = Convert.ToDecimal(Console.ReadLine());
            double count = Convert.ToDouble(decimal.Remainder(argument, 1));
            string number = count.ToString();
            int decimalCount = 0;
            if (number.Length > 1)
            {
                decimalCount = number.Length - 2;
            }
            Console.WriteLine("decimal:" + decimalCount);
            Console.ReadKey();
            
        }
    }
