    using (Isolated<Work> isolated = new Isolated<Work>())
                {
                    Thread TestThread = new Thread(new ParameterizedThreadStart(isolated.Value.COM_StartCommand));
                    TestThread.Start("COM4");
    
                Thread.Sleep(5000);
                TestThread.Abort();
                }
    
                for (int i = 0; i < 1000; i++)
                {
                    Console.WriteLine("bump" + i);
                    Thread.Sleep(1000);
                }
