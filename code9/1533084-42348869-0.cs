    class Class1
    {
        void DoSomething()
        {
            var timer = new DispatcherTimer();
            var m1 = new Manager(timer);
            var m2 = new Manager(timer);
            var m3 = new Manager(timer);
            var m4 = new Manager(timer);
        }
    }
    abstract class BaseManager
    {
        protected abstract void Timer_Tick(object sender, object e);
        protected BaseManager(DispatcherTimer timer)
        {
            timer.Tick += Timer_Tick;
        }
    }
    class Manager: BaseManager
    {
        public Manager(DispatcherTimer timer)
        : base(timer) { }
        protected override void Timer_Tick(object sender, object e)
        {
            throw new NotImplementedException();
        }
    }
