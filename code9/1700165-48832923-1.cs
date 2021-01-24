            Driver driver;   
            for (var a = 0; a < 5; a++)
            {
                driver = new Driver();
                Console.WriteLine("Enter the Drivers Name");
                string driverName = driver.Name(Console.ReadLine());
                Console.WriteLine("Enter the Drivers Occupation");
                string driverOccupation = driver.Occupation(Console.ReadLine());
                Console.WriteLine("How many claims does this driver have?");
                int noOfClaims = driver.Claim(int.Parse(Console.ReadLine()));
                Console.WriteLine("Your car details: \n " + driverName + " \n " + driverOccupation + "\n " + noOfClaims);
               MyDriver.Add(driver);
            }
