    public interface IProcessInput
    {
    }
    public interface IProcessable<in TInput, out TOutput> where TInput : IProcessInput
    {
        TOutput Result { get; }
    
        TOutput Execute(TInput args);
    }
    public abstract class ProcessInput: IProcessInput
    {
        protected ProcessInput(int count)
        {
            Count = count;
        }
        public virtual int Count { get; private set; }
    }
    public class WithoutProcessInput : ProcessInput
    {
        public WithoutProcessInput() : base(0)
        {
        }
    }
