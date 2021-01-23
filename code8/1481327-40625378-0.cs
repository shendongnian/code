    public class MainViewModel : ReactiveObject
    {
        private readonly ObservableAsPropertyHelper<bool> _isLoading;
        public MainViewModel()
        {
            Load = ReactiveCommand.CreateFromTask(async () =>
            {
                // Simulating a long running task, like DB query
                await Task.Delay(TimeSpan.FromSeconds(10));
                // Populating list
                Items.Clear();
                Items.AddRange(Enumerable.Range(0, 30).Where(x => x%2 == 0));
            });
            Load.IsExecuting.ToProperty(this, x => x.IsLoading, out _isLoading);
        }
        public bool IsLoading => _isLoading.Value;
        public ReactiveList<int> Items { get; } = new ReactiveList<int>();
        public ReactiveCommand<Unit, Unit> Load { get; }
    }
