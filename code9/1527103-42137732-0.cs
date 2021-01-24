    public class GetNumberStateMachine : IAsyncStateMachine
    {
        // ....
        void IAsyncStateMachine.MoveNext()
        {
            // here your actual code happens in steps between the 
            // await calls
        }
    }
