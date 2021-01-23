    static void Main(string[] args)
    {
        double avr = 0;
        double sum = 0;
        double max = 0;
        double min = Double.MaxValue; // *** Initially set to maximum possible number ***
        Console.WriteLine("How many numbers?");
        int b = Convert.ToInt32(Console.ReadLine());
        for (int i = 0; i < b; i++)
        {
            double number = Convert.ToDouble(Console.ReadLine());
            if (number >= max)
            {
                max = number;
            }
            if (number <= min) // *** The else is removed here ***
            {
                min = number;
            }
            sum += number;
        }
        sum = sum - max - min; // Exclude lowest and hightest value
        avr = sum / (b - 2); // Average excluding lowest and highest value
        Console.WriteLine("sum = {0}, average = {1}, max = {2}, min = {3}", sum, avr, max, min);
        Console.ReadKey();
    }
