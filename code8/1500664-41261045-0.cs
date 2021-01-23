    Task.Run(()=> 
            {
                for (int i = 1; i <= 9999; i++)
                {
                    System.Threading.Thread.Sleep(1500); //simulate long-running operation by sleeping for 1.5s seconds... 
                    label1.Dispatcher.BeginInvoke(new Action(() => label1.content = 100 * i / 9999 + "%"));
                }
            });
