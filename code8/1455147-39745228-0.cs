    static void Main(string[] args)
                {
                    Thread stopThread = new Thread(delegate ()
                    {
                        TimeSpan day = new TimeSpan(24, 00, 00);    // 24 hours in a day.
                        TimeSpan now = TimeSpan.Parse(DateTime.Now.ToString("HH:mm"));     // The current time in 24 hour format
                        TimeSpan activationTime = new TimeSpan(6, 0, 0);    // 6 AM
        
                        TimeSpan timeLeftUntilFirstRun = ((day - now) + activationTime);
                        if (timeLeftUntilFirstRun.TotalHours > 24)
                            timeLeftUntilFirstRun -= new TimeSpan(24, 0, 0);
                        Console.WriteLine($"Closing in {(int)timeLeftUntilFirstRun.TotalMinutes} Minutes");
                        Thread.Sleep((int)timeLeftUntilFirstRun.TotalMilliseconds);
                        Environment.Exit(0);
                    })
                    { IsBackground = true};
                    stopThread.Start();
        
                    Console.WriteLine("Waiting");
                    Console.ReadLine();
                }
            }
