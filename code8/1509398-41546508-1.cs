     string[] dates = { "10-10-2015", "41-50-5880", "awewe" };
            foreach (var Date in dates)
            {
                try
                {
                    Console.WriteLine(DateTime.Parse(Date));
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invaid Date");
                }
            }
