        CancellationTokenSource _source;
        public Cancel (CancellationTokenSource source)
        {
           _source = source;
        }
        public void cancelTask()
        {            
            _source.Cancel();
        }
    }
