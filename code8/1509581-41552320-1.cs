    Task.Run(() =>
                {
                    for (int i = 0; i< 100; ++i)
                    {
                        Application.Current.Dispatcher.Invoke(new Action(() => Items.Add(i.ToString())));
                        Thread.Sleep(2000);
                    }
                });
