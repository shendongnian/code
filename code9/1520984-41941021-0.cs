    public class FaultCounter {
        private ConcurrentStack<Exception> faultsSinceLastSuccess;        
        public async void RunServiceCommand() {
            faultsSinceLastSuccess = new ConcurrentStack<Exception>();
            var faultCounter = StartFaultLogging(new CancellationTokenSource());
            var worker = DoWork(new CancellationTokenSource());
            await Task.WhenAll(faultCounter, worker);
            Console.WriteLine("Done.");
        }
        public async Task StartFaultLogging(CancellationTokenSource cts) {
            while (true && !cts.IsCancellationRequested) {
                Logger.Error($"{faultsSinceLastSuccess.Count} failed attempts to get work since the last known success.");
                faultsSinceLastSuccess.Clear();
                await Task.Delay(300 * 1000);
            }
        }
        public async Task<object> DoWork(CancellationTokenSource cts) {            
            while (true) {
                object work = null;
                try {
                    work = await GetWork();
                    cts.Cancel();
                    return work;
                }
                catch (Exception ex) {
                    faultsSinceLastSuccess.Push(ex);
                }
            }
        }
    } 
