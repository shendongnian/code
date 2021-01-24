                Task.Factory.StartNew(() => {
                var dataReceivedEvent = new AutoResetEvent(false);
                var ct = _canecellationTokenSource.Token;
                var controller = new DummyMicrocontroller();
                DataReceivedEventHandler onDataReceived = (cmd) => { dataReceivedEvent.Set(); };
                controller.DataReceived += onDataReceived;
                var cmdNumber = 1;
                while (!ct.IsCancellationRequested)
                {
                    var cmd = $"Command{cmdNumber}";
                    controller.Send(cmd);
                    var succeeded = dataReceivedEvent.WaitOne(TimeSpan.FromSeconds(3));
                    if (succeeded)
                    {
                        AddItemSafe(feedbackControl, $"Received confirmation for {cmd}");
                    }
                    else
                    {
                        AddItemSafe(feedbackControl, $"Error receiving confirmation for {cmd}");
                    }
                    cmdNumber++;
                }
                controller.DataReceived -= onDataReceived;
            }, _canecellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
