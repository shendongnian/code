    public class WorkItem {
        public async Task DoWork(IProgress<bool> completionNotification) {
            await Task.Delay(TimeSpan.FromSeconds(2));
            //Work Done
            completionNotification.Report(true);
        }
        //Get, Set, Fire Property change etc
        public bool Completed {
            get; set;
        }
    }
    public class ViewModel {
        public async void ButtonClickHandler(object sender, EventArgs e) {
            var workitemTasks = WorkItems.Select(workItem =>
                workItem.DoWork(new Progress<bool>(done => workItem.Completed = done)))
                .ToList();
            await Task.WhenAll(workitemTasks);
        }
        //Get, Set, Fire Property change etc
        public IEnumerable<WorkItem> WorkItems {
            get; set;
        }
    }
