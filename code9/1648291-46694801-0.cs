    var task = Task.Factory.StartNew(() => {
                        Thread.Sleep(2000);
                        Console.WriteLine("Setting status");
                        Status = "Yes I set it";
                        }, CancellationToken.None);
