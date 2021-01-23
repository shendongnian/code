        Console.Write("Input:");
        int number = int.Parse(Console.ReadLine());
        List<int> numbers = new List<int>();
        List<int> acceptedNumbers = new List<int>();
        for (int i = 1; i <= number; i++)
        {
            numbers.Add(i);
        }
        
        foreach (var num in numbers)
        {
            bool rejected = false;
            char[] numChars = num.ToString().ToCharArray();
            foreach (var numChar in numChars)
            {
                if (numChars.Where(n => n == numChar).Count() > 1)
                {
                    rejected = true;
                }
            }
            if (!rejected)
            {
                acceptedNumbers.Add(num);
            }
        }
        acceptedNumbers.ForEach(n => Console.Write($"{n} "));
        Console.Read();
