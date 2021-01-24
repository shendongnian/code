    while (true)
    {
        int temperature = 0;
        string choice;
        do
        {
            Console.Write("Enter the temperature: ");
            choice = Console.ReadLine();
            if (choice.ToUpper().Equals("Q"))
                return;
        } while (Int32.TryParse(choice, out temperature) == false);
        if (temperature < 17 || temperature > 25)
        {
            Console.WriteLine("Temp is {0} and its too {1} to take a bath", temperature, temperature < 17 ? "cold" : "hot");
        }
        else
        {
            Console.WriteLine("Temp is MADE TO 20, thou it is {0}, it's ok to bath", temperature);
        }
    }
