        private static string AddProcessesInformation(XmlWriterSettings xmlWriterSettings)
        {
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;
            var contextInfo = new StringBuilder();
            var processInformationTask = Task<string>.Factory.StartNew(() =>
            {               
                for(int i = 0; i < 10; i++)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Cancellation request for the ProcessInformationTask");
                        return string.Empty;
                    }
                    Thread.Sleep(1000);
                }
                return "Ran without problems'";
            }, token);
            if (!processInformationTask.Wait(5000, token))
            {
                Console.WriteLine("ProcessInformationTask timed out");
                tokenSource.Cancel();
            }
            return processInformationTask?.Result;
        }
