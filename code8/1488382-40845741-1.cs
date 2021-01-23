    public static void Main()
    {
        int sum = 0;
        string temp = "";
        for (long i = 2; i < 100; i++)
        {
            temp = i.ToString();
            for(int y = 0; y < temp.Length; y++)
            {
                int digit = Convert.ToInt32(temp.Substring(y,1));
                sum += Math.Pow(digit,4);
            }
            sum = 0;
            Console.WriteLine("i = {0}, sum = {1}", i, sum);
        }
    }
