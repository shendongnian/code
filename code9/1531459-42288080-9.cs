    private struct LoopAsyncStateMachine : IAsyncStateMachine
    {
      public int _state;
      public AsyncTaskMethodBuilder _builder;
      public TestAsync _this;
      public int _count;
      private TaskAwaiter _awaiter;
      void IAsyncStateMachine.MoveNext()
      {
        try
        {
          if (_state != 0)
          {
            _count = 0;
            goto afterSetup;
          }
          TaskAwaiter awaiter = _awaiter;
          _awaiter = default(TaskAwaiter);
          _state = -1;
        loopBack:
          awaiter.GetResult();
          awaiter = default(TaskAwaiter);
          _count++;
        afterSetup:
          if (_count < 5)
          {
            awaiter = _this.SomeNetworkCallAsync().GetAwaiter();
            if (!awaiter.IsCompleted)
            {
              _state = 0;
              _awaiter = awaiter;
              _builder.AwaitUnsafeOnCompleted<TaskAwaiter, TestAsync.LoopAsyncStateMachine>(ref awaiter, ref this);
              return;
            }
            goto loopBack;
          }
          _state = -2;
          _builder.SetResult();
        }
        catch (Exception exception)
        {
          _state = -2;
          _builder.SetException(exception);
          return;
        }
      }
      [DebuggerHidden]
      void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine param0)
      {
        _builder.SetStateMachine(param0);
      }
    }
    public Task LoopAsync()
    {
      LoopAsyncStateMachine stateMachine = new LoopAsyncStateMachine();
      stateMachine._this = this;
      AsyncTaskMethodBuilder builder = AsyncTaskMethodBuilder.Create();
      stateMachine._builder = builder;
      stateMachine._state = -1;
      builder.Start(ref stateMachine);
      return builder.Task;
    }
