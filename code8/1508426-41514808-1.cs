    public class ViewModel
    {
        public ObservableCollection<Process> Processes { get; }
            = new ObservableCollection<Process>();
        public void Update()
        {
            var currentIds = Processes.Select(p => p.Id).ToList();
            foreach (var p in Process.GetProcesses())
            {
                if (!currentIds.Remove(p.Id))
                {
                    Processes.Add(p);
                }
            }
            foreach (var id in currentIds)
            {
                Processes.Remove(Processes.First(p => p.Id == id));
            }
        }
    }
