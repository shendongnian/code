                try
                {
                    lockFile = File.OpenWrite("SingleInstance.lck");
                }
                catch (Exception)
                {
                    Console.WriteLine("ERROR - Server is already running. End that instance before re-running. Exiting in 5 seconds...");
                    System.Threading.Thread.Sleep(5000);
                    return;
                }
