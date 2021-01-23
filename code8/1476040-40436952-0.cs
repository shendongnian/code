        int age;
        string result;
        Console.WriteLine("Please enter your age!");
        age = Convert.ToInt32(Console.ReadLine());
        if (age >= 18)
        {
            result = "You can drink alcohol!";
        }
        else
        {
            result = "You can't drink alcohol!";
        }
        Console.WriteLine(result);
        Console.ReadKey();
