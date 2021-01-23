    class Program
    {
        private class MenuOption
        {
            public string Description { get; }
            public Action Run { get; }
            public MenuOption(string description, Action run)
            {
                Description = description;
                Run = run;
            }
        }
        static void Main(string[] args)
        {
            int option;
            var menuOptions = buildMenuOptions();
            do
            {
                Console.WriteLine($"This is a system to calculate: {string.Join(", ", menuOptions.Values.Take(menuOptions.Count-1).Select(o => o.Description))}");
                Console.WriteLine(string.Join(" - ", menuOptions.Select(kv => $"{kv.Key} = {kv.Value.Description}")));
                Console.WriteLine($"Please enter which calculation you would like to perform. [{string.Join(", ", menuOptions.Keys)}]");
            } while (!tryValidateUserOption(menuOptions, out option));
            menuOptions[option].Run();
            Console.Write("Press key to exit... ");
            Console.ReadKey();
        }
        private static IDictionary<int, MenuOption> buildMenuOptions() =>
            new Dictionary<int, MenuOption>() { { 1, new MenuOption("Speed", () => runSpeedOption()) },
                                                { 2, new MenuOption("Distance", () => runDistanceOption()) },
                                                { 3, new MenuOption("Time", () => runTimeOption())},
                                                { 4, new MenuOption("Quit", () => { return; }) } };
        private static bool tryValidateUserOption(IDictionary<int, MenuOption> options, out int selectedOption)
        {
            var input = Console.ReadLine();
            if (!int.TryParse(input, out selectedOption) ||
                !options.ContainsKey(selectedOption))
            {
                Console.WriteLine("Invalid option. Please try again.");
                return false;
            }
            return true;
        }
        private static void runTimeOption()
        {
            int miles;
            double speed;
            Console.WriteLine("You have chose to calculate Time. T = D/S.");
            getUserInput("To work this out you need to firstly enter your distance in miles.", 0, int.MaxValue, out miles);
            getUserInput("Now enter your Speed in MPH.", 0, double.MaxValue, out speed);
            Console.WriteLine("Your Time is " + miles / speed + " hours.");
            Console.WriteLine("This would be " + miles / speed * 60 + " minutes");
        }
        private static void runDistanceOption()
        {
            int speed;
            double time;
            Console.WriteLine("You have chose to calculate distance. D = SxT.");
            getUserInput("To work this out you need to firstly enter your speed.", 0, int.MaxValue, out speed);
            getUserInput("Now enter your time in hours.", 0, double.MaxValue, out time);
            Console.WriteLine("Now enter your time in hours.");
            Console.WriteLine("Your Distance is " + speed * time + " miles");
        }
        private static void runSpeedOption()
        {
            int distance, time;
            Console.WriteLine("You have chose to calculate speed. S = D/T");
            getUserInput("To work this out you need to firstly enter your distance in metres.", 0, int.MaxValue, out distance);
            getUserInput("Now enter your time in seconds.", 0, int.MaxValue, out time);
            Console.WriteLine("Your speed is " + distance / time + " m/s");
            Console.WriteLine("In MPH this is " + distance / time * 2.23 + " MPH");
        }
        private static void getUserInput(string message, int lowerInclusiveBound, int upperExclusiveBound, out int value)
        {
            while (true)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                if (int.TryParse(input, out value) &&
                    value >= lowerInclusiveBound &&
                    value < upperExclusiveBound)
                    return;
                Console.WriteLine("Input is not a valid value. Please try again.");
            }
        }
        private static void getUserInput(string message, double lowerInclusiveBound, double upperExclusiveBound, out double value)
        {
            while (true)
            {
                Console.WriteLine(message);
                var input = Console.ReadLine();
                if (double.TryParse(input, out value) &&
                    value >= lowerInclusiveBound &&
                    value < upperExclusiveBound)
                    return;
                Console.WriteLine("Input is not a valid value. Please try again.");
            }
        }
    }
