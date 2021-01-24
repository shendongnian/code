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
  [1]: https://github.com/dotnet/roslyn/blob/5fc230a431f596fcfbb65d246573b45f164db23a/src/Compilers/CSharp/Test/Emit/CodeGen/CodeGenAsyncTests.cs
  [2]: https://msdn.microsoft.com/en-us/library/system.runtime.compilerservices.asyncvoidmethodbuilder(v=vs.110).aspx
