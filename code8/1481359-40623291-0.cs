            int roomIs = 0;
            Console.WriteLine("Hello World. Type /Help for help or /Play to play!");
            roomIs = 1;
            var Enter = default(string);
            do
            {
                Enter = Console.ReadLine();
                switch (Enter)
                {
                    case ("/Help"):
                        Console.Clear();
                        Console.WriteLine("Welcome to the help room, type /Return to return to your last room!");
                        break;
                    case ("/Return"):
                        if (roomIs == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Hello World. Type /Help for help or /Play to play!");
                        }
                        break;
                }
            }
            while (!string.IsNullOrEmpty(Enter));
