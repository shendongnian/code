    DoWork(new MyResult() {
        OnSuccess = () => Console.WriteLine("Success"),
        OnError = ()=>Console.WriteLine("Error") }
    );
----
    public class MyResult
    {
        public Action OnSuccess { set; get; }
        public Action OnError { set; get; }
    }
    void DoWork(MyResult callback)
    {
        Console.WriteLine("doing work");
        callback.OnSuccess();
    }
