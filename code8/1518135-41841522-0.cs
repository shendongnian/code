    public static void BMR(string[] args)
    {
        int weight, height, age, gender;
        Console.Write("Enter your age in years");
        age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter your weight in pounds");
        weight = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter your height in inches");
        height = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Gender? Enter male/female (1 for Male, 2 for Female)");
        gender = Convert.ToInt32(Console.ReadLine());
        if (gender == 1)
        {
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Height:" + height);
            Console.WriteLine("Weight:" + weight);
            Console.WriteLine("Gender:" + gender);
            Console.WriteLine("Your BMR is" + (66.0m + (6.23m * weight) + (12.7m * height) - (6.8m * age)));
        }
        else
        {
            Console.WriteLine("Age: " + age);
            Console.WriteLine("Height:" + height);
            Console.WriteLine("Weight:" + weight);
            Console.WriteLine("Gender:" + gender);
            Console.WriteLine("Your BMR is " + (655.0m + (4.35m * weight) + (4.7m * height) - (4.7m * age)));
        }
    }
