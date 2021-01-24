    public static class Test
    {
        public static int i = 10;
        public static int j = new Func<int>(() => { Console.WriteLine("Static field initializer called."); return 20; })();
        static Test()
        {
            Console.WriteLine("Static Constructor called.");
        }
    }
