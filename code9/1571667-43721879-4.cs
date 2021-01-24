    public class BackgroundJob {
        public int Progress { get; private set; }
        public event EventHandler ProgressUpdated;
        public async Task Start(CancellationToken token) {
            for (var i = 0; i < 100; i++) {
                token.ThrowIfCancellationRequested();
                await Task.Delay(1000);
                Progress++;
                ProgressUpdated?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public class Program {        
        private static CancellationTokenSource cts = new CancellationTokenSource()
        static async Task MainAsync() {
            var job = new BackgroundJob();
            job.ProgressUpdated += Job_ProgressUpdated;
            try {
                await job.Start(cts.Token);
            } catch (OperationCanceledException ex) {
                Console.WriteLine($"The job failed with an error: {ex}");
            }
        }
        private static async void Job_ProgressUpdated(object sender, EventArgs e) {
            var job = (BackgroundJob)sender;
            await Task.Delay(100); // just an example - my real code needs to call async methods.
            Console.WriteLine($"The Job is at {job.Progress}%.");
            if (job.Progress == 5)
                cts.Cancel();
        }
        static void Main(string[] args) {
            MainAsync().GetAwaiter().GetResult();
            Console.WriteLine("Reached the end of the program.");
            Console.ReadKey();
        }
    }
