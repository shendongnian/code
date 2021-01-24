    [MethodImplAttribute(MethodImplOptions.NoInlining)] // Methods containing StackCrawlMark local var have to be marked non-inlineable            
        public Task<TResult> StartNew<TResult>(Func<TResult> function)
        {
            StackCrawlMark stackMark = StackCrawlMark.LookForMyCaller;
            Task currTask = Task.InternalCurrent;
            return Task<TResult>.StartNew(currTask, function, m_defaultCancellationToken,
                m_defaultCreationOptions, InternalTaskOptions.None, GetDefaultScheduler(currTask), ref stackMark);
        }
