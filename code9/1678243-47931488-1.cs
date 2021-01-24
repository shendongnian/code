    public interface IMyGen
    {
        object Value { get; }
    }
    public class MyGen<T> : IMyGen
    {
        public MyGen(T val)
        {
            Val = val;
        }
        public T Val { get; }
        public object Value => Val;
    }
    public class Proc
    {
        public void Do(params IMyGen[] arr)
        {
        }
    }
