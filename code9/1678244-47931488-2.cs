    public interface IMyGen
    {
        object Val { get; }
    }
    public class MyGen<T> : IMyGen
    {
        public MyGen(T val)
        {
            Val = val;
        }
        public T Val { get; }
        object IMyGen.Val => this.Val;
    }
    public class Proc
    {
        public void Do(params IMyGen[] arr)
        {
        }
    }
