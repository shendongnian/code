    public async Task<int> GetNumber()
    {
         GetNumberStateMachin stateMachine = new GetNumberStatemachine();
         stateMachine.\u003C\u003Et__builder = AsyncTaskMethodBuilder<int>.Create();
         stateMachine.\u003C\u003E1__state = -1;
         stateMachine.\u003C\u003Et__builder.Start<GetNumberStatemachine>(ref stateMachine);
         return stateMachine.\u003C\u003Et__builder.Task;
    }
