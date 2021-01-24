    protected virtual async Task StartAllWorkersAsync()
            {
                var ediCustomersToStart = EdiDataAccess.GetEdiCostumersToStart();
                var ediTasks = ediCustomersToStart
                    .Select(StartWorkerAsync)
                    .ToList();
                await TaskEx.WhenAll(ediTasks);
            }
