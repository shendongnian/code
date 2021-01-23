    public class MyStartupForm
    {
        public List<string> LoadedNetworkComputers {get; private set;}
        private async OnFormLoad()
        {
            // start doing the things async.
            // keep the UI responsive so it can inform the operator
            var taskLoadComputers = LoadNetworkComputers();
            var taskLoadWidgets = LoadWidgets();
            // while loading the Computers and Widgets: inform the operator
            // what the program is doing:
            this.InformOperator();
            // Now I have nothing to do, so let's await for both tasks to complete
            await Task.WhenAll(new Task[] {taskLoadComputers, taskLoadWidgets});
            
            // remember the result of loading the network computers:
            this.LoadedNetworkComputers = taskLoadComputers.Result;
            // Close myself; my creator will continue:
            this.Close();
        }
    }
