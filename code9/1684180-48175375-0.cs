        string[] numbers = new string[10];
        bool found = false;
        for(int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Console.ReadLine();
            if(numbers[i] == "x")
            {
                break;
            }
        }
        for (int i = 0; i < numbers.Length; i++)
        {
            if(numbers[i] != "x")
            {
                if (Int32.Parse(numbers[i]) % 2 == 0)
                {
                    found = true;
                    Console.WriteLine(numbers[i]);
                }
            }
        }
        if(found == false)
        {
             Console.WriteLine("N/A");
        }
        Console.ReadLine(); //So you can pause and see the output.
