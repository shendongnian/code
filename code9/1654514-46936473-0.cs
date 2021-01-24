    public class JobManager
    {
        private Queue<Action> plainQueue;
        private Queue<Action<Vector3>> vectorQueue;
    
        public void AddAction(Action action)
        {
            plainQueue.Enqueue(action);
        }
    
        public void AddAction(Action<Vector3> action)
        {
            vectorQueue.Enqueue(action);
        }
    }
