     string weigt_st = Console.ReadLine();
                int femaleWeight = 0;
                try
                {
                    femaleWeight = int.Parse(weigt_st);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
