            var processInformationTask = Task<string>.Factory.StartNew(() =>
            {
                try
                {
                    Method1(token);
                    Thread.Sleep(1000);
                    Method2(token);
                    Thread.Sleep(1000);
                }
                catch(OperationCanceledException ex)
                {
                    return string.Empty;
                }
                return "Ran without problems'";
            }, token);
        private static void Method1(CancellationToken token)
        {
            token.ThrowIfCancellationRequested();
            // do more work
        }
