    public interface ISubscription
    {
        bool IsAlive { get; }
        void Fire();
    }
    public class Subscrition<T> : ISubscription
        where T: class
    {
        public Subscrition(T target, Action<T> fire)
        {
            this.Target = new WeakReference<T>(target);
            this.FireHandler = fire;
        }
        public WeakReference<T> Target { get; }
        public Action<T> FireHandler { get; }
        public bool IsAlive => this.Target.TryGetTarget(out var t);
        public void Fire()
        {
            if (this.Target.TryGetTarget(out var target))
            {
                this.FireHandler(target);
            }
        }
    }
    public class WeakEvent
    {
        List<ISubscription> weakHandlers = new List<ISubscription>();
        public void Register<T>(T target, Action<T> fire)
            where T:class
        {
            this.Prune();
            this.weakHandlers.Add(new Subscrition<T>(target, fire));
        }
        public void Unregister(ISubscription subscription)
        {
            this.Prune();
            this.weakHandlers.Remove(subscription);
        }
        // Prune any dead handlers.
        public void Prune()
        {
            this.weakHandlers.RemoveAll(_ => !_.IsAlive);
        }
        public void Fire()
        {
            this.Prune(); 
            this.weakHandlers.ForEach(_ => _.Fire());
            
        }
    }
