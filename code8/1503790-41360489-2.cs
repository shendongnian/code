    public class ParallelProcessor
    {
        private Action[] actions;
        private int maxConcurrency;
    
        public ParallelProcessor(Action[] actionList, int maxConcurrency)
        {
            this.actions = actionList;
            this.maxConcurrency = maxConcurrency;
        }
    
        public void RunAllActions()
        {
            if (Utility.IsNullOrEmpty<Action>(actions))
                throw new Exception("No Action Found!");
    
            using (var concurrencySemaphore = new SemaphoreSlim(maxConcurrency))
            {
                Task.WaitAll(actions.Select(a => Task.Run(() =>
                    {
                        concurrencySemaphore.Wait();
                        try { a(); }
                        finally { concurrencySemaphore.Release(); }
                    })).ToArray());
            }
        }
    }
