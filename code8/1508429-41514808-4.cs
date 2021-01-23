    public class ViewModel
    {
        public ObservableCollection<Process> Processes { get; }
            = new ObservableCollection<Process>();
        public void Update()
        {
            var currentIds = Processes.Select(p => p.Id).ToList();
            foreach (var p in Process.GetProcesses())
            {
                if (!currentIds.Remove(p.Id)) // it's a new process id
                {
                    Processes.Add(p);
                }
            }
            foreach (var id in currentIds) // these do not exist any more
            {
                Processes.Remove(Processes.First(p => p.Id == id));
            }
        }
    }
