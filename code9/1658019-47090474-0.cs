    public class MyClass
    {
        public MyClass(
            MySetting setting,
            IMyService service1,
            IMyService service2,
            IMyService service3)
        {
            this.Service1 = service1;
            this.Service2 = service2;
            this.Service3 = service3;
        }
        public IMyService Service1 { get; }
        public IMyService Service2 { get; }
        public IMyService Service3 { get; }
        public string DoIt()
        {
            return
                this.Service1.Whatever() +
                this.Service2.Whatever() +
                this.Service3.Whatever();
        }
    }
