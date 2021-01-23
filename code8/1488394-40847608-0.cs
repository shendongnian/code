    public static void Main()
    {
        for (long i = 2; i < 100; i++)
        {
            int sum = 0;
            foreach (var digit in i.ToString().Select(digit => int.Parse(digit.ToString())))
            {
                sum += Convert.ToInt32(Math.Pow(Convert.ToInt32(digit), 4));
            }
            Console.WriteLine("i = {0}, sum = {1}", i, sum);
        }
    }
