    public class MyServiceBuilder
    {
        private IObjectA ObjectA;
        private IObjectB ObjectB;
        private MyServiceBuilder(IObjectA objectA, IObjectB objectB)
        {
            ObjectA = objectA;
            ObjectB = objectB;
        }
        public static MyServiceBuilder Create()
        {
            return new MyServiceBuilder(new ObjectA(), new ObjectB());
        }
        public MyServiceBuilder WithCachingForA()
        {
            ObjectA = new CachingDecoratorForA(ObjectA);
            return this;
        }
        public MyServiceBuilder WithLoggingForB()
        {
            ObjectB = new LoggingDecoratorForB(ObjectB);
            return this;
        }
        public MyServiceBuilder WithPerformanceRecorderForB()
        {
            ObjectB = new PerformanceRecorderForB(ObjectB);
            return this;
        }
        public MyService Build()
        {
            return new MyService(ObjectA, ObjectB);
        }
    }
