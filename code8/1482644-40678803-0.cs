    public class MyStartupForm
    {
        public List<string> LoadedNetworkComputers {get; private set;}
        private async OnFormLoad()
        {
            // start doing the things async.
            // keep the UI responsive so it can inform the operator
            var taskLoadComputers = LoadNetworkComputers();
            var taskLoadWidgets = LoadWidgets();
            await Task.WhenAll(new Task{} {taskLoadComputers, taskLoadWidgets});
            
            this.LoadedNetworkCoputers = taskLadComputers.Result;
            this.Close();
        }
    }
