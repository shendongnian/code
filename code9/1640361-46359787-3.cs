    public class Customer
    {
        public Customer()
        {
            Events.OnInvoke += (sender, args) => Call();
        }
    }
