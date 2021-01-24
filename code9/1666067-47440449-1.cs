            private static IWebDriver driver;
            private static Dispatcher dispatcher = null;
            AutoResetEvent waitHandle = new AutoResetEvent(false);            
            var thread = new Thread(() =>
            {
                dispatcher = Dispatcher.CurrentDispatcher;
                waitHandle.Set();
                Dispatcher.Run();
            });
            thread.Start();
            waitHandle.WaitOne();
            
            // Now you can use dispatcher.Invoke anywhere you want
            dispatcher.Invoke(() =>
            {
                driver = new ChromeDriver(@"myPath");
            });
            // And async for not blocking the UI thread
            dispatcher.BeginInvoke(new Action(() =>
            {
                myFunctionUsingDriverObject(); 
            }));
            // or using await
            await dispatcher.InvokeAsync(() =>
            {
                
            });
            // And when you are done, you can shut the thread down
            dispatcher.InvokeShutdown();
           
