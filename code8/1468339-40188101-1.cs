    public static string AgeAndLabel()
    {
        string userAge;
        Console.WriteLine("Enter your age.");
        int ageValue = int.Parse(Console.ReadLine());
    
        if (ageValue < 18)
            userAge = "Minor";
        else
            userAge = "Adult";    
        return userAge;
    }
