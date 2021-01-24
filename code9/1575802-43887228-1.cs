    class FooBar
    {
        public Foo Input { get; set; }
        public Bar Result { get; set; }
        public Task<Bar> Task { get { return _taskSource.Task; } }
        
        public void Complete()
        {
            _taskSource.SetResult(Result);
        }
        private TaskCompletionSource<Bar> _taskSource = new TaskCompletionSource<Bar>();
    }
