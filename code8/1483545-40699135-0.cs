    public interface IType { }
    public class TypeA : IType { }
    public class TypeB : IType { }
    public class Worker<T> where T : IType
    {
        public string Message { get; set; }
        public void DoWork()
        {
            Console.WriteLine(Message);
        }
    }
    public static class WorkerExtensions
    {
        public static Worker<TypeA> DoWorkA1(this Worker<TypeA> w, string input)
        {
            w.Message = input;
            return w;
        }
        public static Worker<TypeA> DoWorkA2(this Worker<TypeA> w, string input)
        {
            w.Message += input;
            return w;
        }
        public static Worker<TypeB> DoWorkB(this Worker<TypeB> w, string input)
        {
            w.Message += input;
            return w;
        }
    }
