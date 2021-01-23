    static void Main(string[] args)
        {
            begin();
            Console.ReadLine();
        }
        public static void begin()
        {
            Console.WriteLine("Welcome to your next level Currency Converter!");
            Console.WriteLine("---We---Change---Your---Money---For---You---");
            Console.WriteLine(" -------So---You---Dont---Have---To!-------\n\n");
            Console.WriteLine("What is your base currency?\n");
            Console.WriteLine("1 = SEK, 2= USD or 3= EUR?");
            ConsoleKeyInfo keyPress = Console.ReadKey(true);
            int uConvertFrom = getUserInput(keyPress);
            if (uConvertFrom > -1)
            {
                switch (uConvertFrom)
                {
                    case 1:
                        Console.WriteLine("You have chosen SEK (Swedish Krona)\n");
                        
                        break;
                    case 2:
                        Console.WriteLine("You have chosen USD (United States Dollar)\n");
                        break;
                    case 3:
                        Console.WriteLine("You have chosen EUR (Euro)\n");
                        break;
                }
               
            }
            else
            {
                if (uConvertFrom == -2)
                {
                    //break;
                }
                else
                {
                    Console.WriteLine("You didn't enter a valid response. Please try again");
                    begin();
                }
            }
            Console.WriteLine("Which currency would you like to change your money to?\n");
            keyPress = Console.ReadKey(true);
            int uConvertTo = getUserInput(keyPress);
            if (uConvertTo > -1) {
                switch (uConvertTo)
                {
                    case 1:
                        Console.WriteLine("You have chosen SEK (Swedish Krona)\n");
                        break;
                    case 2:
                        Console.WriteLine("You have chosen SEK (Swedish Krona)\n");
                        break;
                    case 3:
                        Console.WriteLine("You have chosen USD (United States Dollar)\n");
                        break;
                    case 4:
                        Console.WriteLine("You have chosen EUR (Euro)\n");
                        break;
                }
               
            }
            else
            {
                if (uConvertFrom == -2)
                {
                    //break;
                }
                else
                {
                    Console.WriteLine("You didn't enter a valid response. Please try again");
                    begin();
                }
            }
            exchange((decimal)uConvertFrom, (decimal)uConvertTo);
        }
        private static int getUserInput(ConsoleKeyInfo keyPress)
        {
            if (keyPress.Key == ConsoleKey.Escape)
            {
                Console.WriteLine("Thank you for using. Exiting now.");
                return -2;
            }
            int ret = -1;
            if (int.TryParse(keyPress.KeyChar.ToString(), out ret))
            {
                return ret;
            }
            else
            {
                return -1;
            }
        }
        public static decimal exchange(decimal currencyToExchangeFrom, decimal currencyToExchangeTo)
        {
            Console.WriteLine("How much would you like to exchange?\n");
            string amountToExchange = Console.ReadLine();
            decimal amountToConvert = 0;
            decimal.TryParse(amountToExchange, out amountToConvert);
            decimal newValue = (decimal)0.000;
            // SEK
            if (currencyToExchangeFrom == 1)
            {
                // SEK - SEK
                if (currencyToExchangeTo == 1)
                {
                    Console.WriteLine("You have your money, go spend it!");
                }
                // sek -usd
                if (currencyToExchangeTo == 2)
                {
                    newValue = amountToConvert / 8.50m;
                    Console.WriteLine("You now have" + newValue.ToString("C2") + " in USD");
                }
            }
            //sek - eur
            if (currencyToExchangeFrom == 2)
            {
                amountToConvert /= 9.49m;
                Console.WriteLine("You now have" + newValue.ToString("C2") + " in EUR");
            }
            //  usd - eur
            if (currencyToExchangeFrom == 3)
            {
                amountToConvert *= 0.90m;
                Console.WriteLine("You now have" + newValue.ToString("C2") + " in EUR");
            }
            return (decimal).001;
        }
