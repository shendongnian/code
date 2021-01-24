    static void CollectUserInfo()
    {
        // Declar Varibals
        string firstName, lastName;
        // We can define these here so that there isn't a compiler error.
        int birthYear = 0;
        int currentYear = 0;
        int age;
        double maxHeartRate, minTargetHeartRate, maxTargetHeartRate;
    
        // User is asked to enter info
        Console.Write("Enter your first Name: ");
        firstName = Console.ReadLine();
        Console.Write("Enter your last name: ");
        lastName = Console.ReadLine();
        try
        {
            Console.Write("Enter the current year: ");
            currentYear = int.Parse(Console.ReadLine());
            Console.Write("Enter your birth year: ");
            birthYear = int.Parse(Console.ReadLine());
        } 
        catch (Exception)
        {
            // The result of the error. 
            Console.WriteLine("Invalid input.");
            CollectUserInfo();
        }
        // Find Age
        age = findAge(currentYear, birthYear);
    
        // Find Max Heart rate
        maxHeartRate = findMaxHR(age);
    
        // Find Minimum Target Heart Rate
        minTargetHeartRate = findMinTHR(maxHeartRate);
    
        // Find Maximum Target Heart Rate
        maxTargetHeartRate = findMaxTHR(maxHeartRate);
    
        // Display Information
        DisplayInformation(firstName, lastName, age, maxHeartRate, minTargetHeartRate, maxTargetHeartRate);
    
    // Methods
    }
