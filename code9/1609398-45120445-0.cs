    class Program
    {
        static void Main(string[] args)
        {
            BigInteger minThousandDigits = BigInteger.Parse(new string('9', 999)) + 1;
            BigInteger thousandMoreDigits = BigInteger.Parse(new string('5', 1000));
            BigInteger notAThousandDigits = BigInteger.Parse(new string('9', 999));
            //Displays false
            Console.WriteLine($"Is the first number less than a thousand digits? {thousandMoreDigits < minThousandDigits}");
            //Displays true
            Console.WriteLine($"Is the second number less than a thousand digits? {notAThousandDigits < minThousandDigits}");
            Console.ReadLine();
        }
    }
