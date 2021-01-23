    public class ClientClass
    {
        public virtual void DoSomething<T>(IGeneric<T> dependency = null) //must be virtual to be intercepted
        {
            if (dependency == null) throw new ArgumentNullException(nameof(dependency));
            //use dependency here
        }
    }
