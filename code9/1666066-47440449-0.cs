            AutoResetEvent waitHandle = new AutoResetEvent(false);
            Dispatcher dispatcher = null;
            var thread = new Thread(() =>
            {
                dispatcher = Dispatcher.CurrentDispatcher;
                waitHandle.Set();
                Dispatcher.Run();
            });
            thread.Start();
            waitHandle.WaitOne();
            
            // Now you can use dispatcher.Invoke any where you want
            dispatcher.Invoke(() =>
            {
                driver = new ChromeDriver(@"myPath");
            });
            // And async
            dispatcher.BeginInvoke(new Action(() =>
            {
                myFunctionUsingDriverObject(); 
            }));
           
