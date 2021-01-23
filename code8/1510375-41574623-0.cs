                DateTime pin =  DateTime.Parse("jan 11 2017 22:00");
                DateTime pout = DateTime.Parse("Jan 12 2017 7:00");
                TimeSpan spanMe = pout.Subtract(pin);
                Console.WriteLine("Hours : {0}, Minutes : {1}", spanMe.Hours, spanMe.Minutes);
                Console.ReadLine();
