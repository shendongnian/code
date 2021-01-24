    public class BackgroundJob {
        public async Task Start(IProgress<int> progress) {            
            for (var i = 0; i < 100; i++) {
                await Task.Delay(1000);
                progress.Report(i);
                //the method executing the job should determine something is wrong
                if (i == 5)
                    throw new Exception("Something went wrong!");
            }
        }
    }
    public class Program {
        static async Task MainAsync() {
            var job = new BackgroundJob();
            var progress = new Progress<int>(Job_ProgressUpdated);
            try {
                await job.Start(progress);
            } catch (Exception ex) {
                //now your exception is caught
                Console.WriteLine($"The job failed with an error: {ex}");
            }
        }
        private static async void Job_ProgressUpdated(int progress)  {
            await Task.Delay(100); // just an example - my real code needs to call async methods.
            Console.WriteLine($"The Job is at {progress}%.");
            //***
            //a progress updat should not determine if something went wrong
            //***
            //if (progress == 5)
            //throw new Exception("Something went wrong!");
        }
        static void Main(string[] args) {
            MainAsync().GetAwaiter().GetResult();
            Console.WriteLine("Reached the end of the program.");
            Console.ReadKey();
        }
    }
