                string[] readText = File.ReadAllLines(@"C:\Stinger\Configuration\config.cfg");
                foreach (string s in readText)
                {
                    string[] split= s.Split(" ");
                    Console.WriteLine(split[0]+" "+split[1]);
                    Thread.Sleep(1000);
                }
