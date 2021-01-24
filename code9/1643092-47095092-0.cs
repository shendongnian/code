        public void EnqueueWork(WorkRequest request)
        {
            _workQueue.Enqueue(request);
        }
        ConcurrentQueue<WorkRequest> _workQueue = new ConcurrentQueue<WorkRequest>();
        [OperationContract]
        public bool GetWork(out WorkRequest work)
        {
            return _workQueue.TryDequeue(out work);
        }
