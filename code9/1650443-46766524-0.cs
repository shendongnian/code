    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var foo = new FooService();
            foo.StartService(); // UI thrad calling
        }
    }
    public class FooService
    {
        private SynchronizationContext _context;
        private CancellationTokenSource _cts;
        private CancellationToken _token;
        private Task _task;
        public void StartService()
        {
            _context = SynchronizationContext.Current; // Depends on the UI thread being the one to start the service or this will fail
            _cts = new CancellationTokenSource(10000); // Run for 10 seconds
            _token = _cts.Token;
            _task = Task.Run(() => Run(), _token);
        }
        public async Task Stop()
        {
            _cts.Cancel();
            await _task; // wait for task to finish
        }
        private void Run()
        {
            while (!_token.IsCancellationRequested)
            {
                // Do work                
                Thread.Sleep(1000);
                // Alternative use Control.Invoke() if you have access to a UI element, to delegate to the UI thread
                _context.Send((id) => Console.WriteLine($"Delegate from thread {id} to thread {Thread.CurrentThread.ManagedThreadId}"), Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
