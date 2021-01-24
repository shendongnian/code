    public delegate void BeforeMethodExecutionHandler<TArgs>(ILongRunningWithEvents<TArgs> sender, TArgs args, string caller);
    public interface ILongRunningWithEvents<TArgs>
    {
        event BeforeMethodExecutionHandler<TArgs> OnBeforeMethodExecution;
    }
    public class LongRunningClass<TArgs> : ILongRunningWithEvents<TArgs>
    {
        private BeforeMethodExecutionHandler<TArgs> _onBeforeMethodExecution;
        public event BeforeMethodExecutionHandler<TArgs> OnBeforeMethodExecution
        {
            add { _onBeforeMethodExecution += value; }
            remove { _onBeforeMethodExecution -= value; }
        }   
        protected void RaiseOnBeforeMethodExecution(TArgs e, [CallerMemberName] string caller = null)
        {
            _onBeforeMethodExecution?.Invoke(this, e, caller);
        }
    }
    public class ConcreteRunningClass : LongRunningClass<SampleArgs>
    {
        public void SomeLongRunningMethod()
        {
            RaiseOnBeforeMethodExecution(new SampleArgs("Starting!"));
            //Code for the method here
        }
    }
    public class SampleArgs
    {
        public SampleArgs(string message)
        {
            Message = message;
        }
        public string Message { get; private set; }
    }
