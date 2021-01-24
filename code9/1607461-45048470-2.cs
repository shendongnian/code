     public class Communicator
    {
        CancellationTokenSource _canecellationTokenSource = new CancellationTokenSource();
        List<Command> _scenario = new List<Command>(6)
        {
            Command.Trigger(1),
            Command.MoveTo(2),
            Command.Trigger(2),
            Command.MoveTo(3),
            Command.Trigger(3),
            Command.MoveTo(1)
        };
        public void Start(ListBox feedbackControl)
        {
            Task.Factory.StartNew(() => {
                var dataReceivedEvent = new AutoResetEvent(false);
                var ct = _canecellationTokenSource.Token;
                var controller = new DummyMicrocontroller();
                DataReceivedEventHandler onDataReceived = (cmd) => { dataReceivedEvent.Set(); };
                controller.DataReceived += onDataReceived;
                foreach (var cmd in _scenario)
                {
                    if (ct.IsCancellationRequested)
                    {
                        AddItemSafe(feedbackControl, $"Operation cancelled...");
                        break;
                    }
                    AddItemSafe(feedbackControl, cmd.GetMessage(Command.MessageType.Info));
                    controller.Send(cmd);
                    var succeeded = dataReceivedEvent.WaitOne(TimeSpan.FromSeconds(3));
                    var messageType = succeeded ? Command.MessageType.Success : Command.MessageType.Error;
                    AddItemSafe(feedbackControl, cmd.GetMessage(messageType));
                }
                AddItemSafe(feedbackControl, $"Finished executing scenario.");
                controller.DataReceived -= onDataReceived;
            }, _canecellationTokenSource.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
        public void Stop(ListBox feedbackControl)
        {
            AddItemSafe(feedbackControl, $"Attempting to cancel...");
            _canecellationTokenSource.Cancel();
        }
        private void AddItemSafe(ListBox feedbackControl, object item)
        {
            if (feedbackControl.InvokeRequired)
            {
                feedbackControl.Invoke((MethodInvoker)delegate { AddItemSafe(feedbackControl, item); });
            }
            else
            {
                feedbackControl.Items.Add(item);
            }
        }
    }
