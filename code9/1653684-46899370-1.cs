    public class C
    {
        [CompilerGenerated]
        private sealed class <M>d__0 : IAsyncStateMachine
        {
            public int <>1__state;
    
            public AsyncTaskMethodBuilder<bool> <>t__builder;
    
            public C <>4__this;
    
            void IAsyncStateMachine.MoveNext()
            {
                int num = this.<>1__state;
                bool result;
                try
                {
                    result = false;
                }
                catch (Exception arg_0C_0)
                {
                    Exception exception = arg_0C_0;
                    this.<>1__state = -2;
                    this.<>t__builder.SetException(exception);
                    return;
                }
                this.<>1__state = -2;
                this.<>t__builder.SetResult(result);
            }
    
            [DebuggerHidden]
            void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
            {
            }
        }
    
        [DebuggerStepThrough, AsyncStateMachine(typeof(C.<M>d__0))]
        public Task<bool> M()
        {
            C.<M>d__0 <M>d__ = new C.<M>d__0();
            <M>d__.<>4__this = this;
            <M>d__.<>t__builder = AsyncTaskMethodBuilder<bool>.Create();
            <M>d__.<>1__state = -1;
            AsyncTaskMethodBuilder<bool> <>t__builder = <M>d__.<>t__builder;
            <>t__builder.Start<C.<M>d__0>(ref <M>d__);
            return <M>d__.<>t__builder.Task;
        }
    }
