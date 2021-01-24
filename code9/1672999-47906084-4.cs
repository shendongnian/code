     class Program
      {
        static void Main(string[] args)
        {
            var transformCordinator = new TransformCordinator();
            transformCordinator.Do(new Template() { TransformNo = 1, Title = "Hi!" });
            Console.ReadLine();
        }
    }
