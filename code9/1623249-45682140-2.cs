    public class MyAPI
    {
        public event Action<IResult> Callback1;
        public event Action<IResult> Callback2;
        public void StartService()
        {
            //step 1
            int i = 0;
            ConcreteResult result1 = new ConcreteResult();
            result1.i = i;
            Callback1?.Invoke(result1);
            //step 2
            i += 1;
            ConcreteResult result2 = new ConcreteResult();
            result2.i = i;
            Callback2?.Invoke(result2);
            //potentially added in the future
            //i += 1;
            //callback3();
        }
    }
    public static class Program { 
        public static void Main()
        {
            //developers use my API
            var api = new MyAPI();
            api.Callback1 += DeveloperCallback;
            api.Callback2 += DeveloperCallback2;
            api.StartService();
        }
        private static void DeveloperCallback(IResult result)
        {
            Console.WriteLine(result.i);
        }
        private static void DeveloperCallback2(IResult result)
        {
            Console.WriteLine(result.i);
        }
    }
