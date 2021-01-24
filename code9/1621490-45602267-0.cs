    public class Test 
    {
        public static int Main(string[] args)
        {
            var mockCallback = new Mock<ICallback>();
            mockCallback.Setup(t=>t.Call()).Callback(() =>
            { 
                Console.WriteLine("callback called");
            });
            new Test().doWork(mockCallback.Object);
        }
        
        public void DoWork(ICallback callback) 
        {
            Console.WriteLine("doing work");
            callback.Call();
        }
    }
    public interface ICallback
    {
        void Call();
    }
