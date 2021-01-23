    public class WorkItem<Toutput,Tinput>
    {
        private TaskCompletionSource<Toutput> _tcs;
        public Task<Toutput> Task { get { return _tcs.Task; } }
        public Tinput InputData { get; private set; }
        public Toutput OutputData { get; private set; }
        public WorkItem(Tinput inputData)
        {
            _tcs = new TaskCompletionSource<Toutput>();
            InputData = inputData;
        }
        public void Complete(Toutput result)
        {
            _tcs.SetResult(result);
        }
        public void Failed(Exception ex)
        {
            _tcs.SetException(ex);
        }
        public override string ToString()
        {
            return InputData.ToString();
        }
    }
