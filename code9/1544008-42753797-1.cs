    class MyTaskBuilder
    {
        public static MyTaskBuilder Create() => null;
        public void Start<TStateMachine>(ref TStateMachine stateMachine) where TStateMachine : IAsyncStateMachine { }
        public void SetStateMachine(IAsyncStateMachine stateMachine) { }
        public void SetResult() { }
        public void SetException(Exception exception) { }
        public MyTask Task => default(MyTask);
        public void AwaitOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : INotifyCompletion where TStateMachine : IAsyncStateMachine { }
        public void AwaitUnsafeOnCompleted<TAwaiter, TStateMachine>(ref TAwaiter awaiter, ref TStateMachine stateMachine) where TAwaiter : ICriticalNotifyCompletion where TStateMachine : IAsyncStateMachine { }
    }
