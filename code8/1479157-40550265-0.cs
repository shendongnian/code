            int pin;
            int realPin = 1111;
            Console.Write("What's the pin: ");
            foreach (var item in Console.ReadLine())
            {
                if (!int.TryParse(item.ToString(), out pin))
                {
                    Console.Write("Please enter a 4 numbers please: ");
                }
                if (pin.ToString().Length == 4)
                {
                    Console.Write("Please enter a 4 numbers please: ");
                }
                else if (pin != realPin)
                {
                    Console.Write("Wrong Password: ");
                }
            }
