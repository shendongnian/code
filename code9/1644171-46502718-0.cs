        private async void ProcessData()
        {
            while (!processStop)
            {
                await Task.Run
                (
                    () =>
                    {
                        //Do stuff and call regular not async methods
                    }
                ).ConfigureAwait(false);
            }
            processStopped = true;
        }
    This will cause the `ProcessData` to continue on a thread pool and you already use a thread pool by calling `Task.Run`, so it is not a great solution
