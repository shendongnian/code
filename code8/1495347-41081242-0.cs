        static void Menu()
        {
            Console.WriteLine("Menu");
            Console.WriteLine("1) Take me to My fancy menu");
        }
        static void SwitchFunc(string input)
        {
            switch (input)
            {
                case "1":
                    Menu();
                    string inputB = Console.ReadLine();
                    SwitchFunc(inputB);
                    break;
            }
        }
        static void Main(string[] args)
        {
            Menu();
            string input = Console.ReadLine();
            SwitchFunc(input);
        }
