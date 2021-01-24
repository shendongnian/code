    public class BaseMyGen
    {
        
    }
    public class MyGen<T> : BaseMyGen
    {
        public MyGen(T val)
        {
            Val = val;
        }
        public T Val { get; }
    }
    public class Proc
    {
        public void Do(params BaseMyGen[] arr)
        {
            var myGen1 = arr[0] as MyGen<int>;
            var myGen2 = arr[1] as MyGen<string>;
        }
    }
    var proc = new Proc();
    proc.Do(new MyGen<int>(5), new MyGen<string>("bla"));
