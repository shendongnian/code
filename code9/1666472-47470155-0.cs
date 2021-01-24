         Console.Write(WelcomeMessage);
            ConsOut = Console.Out;	//Save the reference to the old out value (The terminal)
            Console.SetOut(new StreamWriter(Stream.Null));  //Remove the console output
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseUrls(url)
                .UseStartup<Startup>()
                .UseApplicationInsights()
                .Build();
            host.Start();   //Start the host in a non-blocking way
            Console.SetOut(ConsOut);    //Put the console output back, after the messages has been written
            Console.CancelKeyPress += OnConsoleCancelKeyPress;
            var waitHandles = new WaitHandle[] {
                CancelTokenSource.Token.WaitHandle
            };
            WaitHandle.WaitAll(waitHandles);    //Wait until the cancel signal has been received
