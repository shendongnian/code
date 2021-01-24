    [Flags]
    public enum EService
    {
        Option1 = 1,
        Option2 = 2,
        Option3 = 4,
        Option4 = 8
    }
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual EService Services { get; set; }
        // Coded here for simplicity, though you'd probably do not want such
        // dependencies here.
        public virtual List<Service> GetServicesEntities(ISession session)
        {
            var services = new List<Service>();
            foreach (EService s in Enum.GetValues(typeof(EService)))
            {
                if ((Services & s) != 0 &&
                    // In case you predefine combinations of options in the enum, you need 
                    // this to avoid having them in the list too.
                    IsPowerOfTwo((int)s))
                {
                    services.Add(
                        // Not a n+1 perf trouble if you have lazy loading batching enabled.
                        session.Load<Service>(s));
                }
            }
            return services;
        }
        // Taken from http://stackoverflow.com/a/600306/1178314
        private bool IsPowerOfTwo(int x)
        {
            return (x != 0) && ((x & (x - 1)) == 0);
        }
    }
