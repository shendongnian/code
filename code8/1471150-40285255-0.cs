        private Thread PropertyChangedQueueThread;
        private List<string> ChangedPropertiesQueue = new List<string>();
        private ManualResetEvent PropertyChangedQueueBlocker = new ManualResetEvent(false);
        private void PropertyChangedQueueWorker()
        {
            while (!this.disposingValue)
            {
                PropertyChangedQueueBlocker.WaitOne();
                lock (ChangedPropertiesQueue)
                {
                    string PropName = ChangedPropertiesQueue.Last();
                    ChangedPropertiesQueue.RemoveAll(i => i == PropName);
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropName));
                }
                if (ChangedPropertiesQueue.Count() == 0)
                    PropertyChangedQueueBlocker.Reset();
            }
        }
        internal void QueuePropertyChangedEvent(string PropertyName)
        {
            ChangedPropertiesQueue.Add(PropertyName);
            PropertyChangedQueueBlocker.Set();
        }
