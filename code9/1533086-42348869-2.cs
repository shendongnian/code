    interface IMangerTimer
    {
        DispatcherTimer Timer { get; }
    }
    class ManagerTimer : IMangerTimer
    {
        public DispatcherTimer Timer { get; } = new DispatcherTimer();
    }
    abstract class BaseManager
    {
        protected abstract void Timer_Tick(object sender, object e);
        protected BaseManager(IMangerTimer timer)
        {
            timer.Timer.Tick += Timer_Tick;
        }
    }
