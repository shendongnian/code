            bool isLetter = false;
            while (!isLetter)
            {
                var pressedKey = Console.ReadKey();
                if (char.IsLetter(pressedKey.KeyChar))
                {
                    isLetter = true;
                }
                else
                {
                    Console.WriteLine("Please input a letter.");
                }
            }
