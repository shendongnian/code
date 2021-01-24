    public class MyClass
    {
        public void StatusEvent(int status)
        {
            Console.WriteLine("Status: {0}", status);
        }
        public void ResultEvent(string cmd, int code)
        {
            Console.WriteLine("Resukt: {0}, {1}", cmd, code);
        }
    }
