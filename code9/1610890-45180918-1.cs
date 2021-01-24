    static void Main(string[] args)
        {
            try
            {
                var b = new MyBot();
                while (true)
                {
                    var input = Console.ReadLine();
                    if (input.Equals("~raid", StringComparison.OrdinalIgnoreCase))
                        b.Start();
                    else if (input.Equals("~stop", StringComparison.OrdinalIgnoreCase))
                        b.Stop();
                    else if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                        break;
                    Task.Delay(1000);
                }
                               
            }
            catch (Exception)
            {
                throw;
            }
        }
