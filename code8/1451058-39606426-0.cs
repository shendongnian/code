    static void Main(string[] args)
    {
        Console.WriteLine(
            "Please enter the number of numbers you would like to find the average for, or add together: ");
        int numofnum = int.Parse(Console.ReadLine());
        int[] numbers = new int[numofnum];
        Console.WriteLine("Would you like to find the average or sum of these numbers? (average/sum)");
        var avsu = Console.ReadLine();
        var sum = 0;
        if (avsu != "average" && avsu != "sum")
        {
            return;
        }
        for (var i = 0; i < numofnum; i++)
        {
            Console.Write("Please enter Number " + i + " to add: ");
            numbers[i] = int.Parse(Console.ReadLine());
        }
        for (var i = 0; i < numofnum; i++)
        {
            Console.WriteLine("You entered the following values: ");
            Console.WriteLine("Number " + i + ": " + numbers[i]);
        }
        if (avsu == "sum")
        {
            sum = numbers.Sum();
            Console.WriteLine("The sim of these numbers is: " + sum);
        }
        if (avsu == "average")
        {
            var average = sum / numbers.Length;
            Console.WriteLine("The average of these numbers is: " + average);
        }
    }
