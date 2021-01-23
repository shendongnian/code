    public class Service1 : IService1
    {
        public List<Nullable<DateTime>> NullTest()
        {
            return new List<Nullable<DateTime>>()
            {
                new Nullable<DateTime>(DateTime.Now),
                new Nullable<DateTime>(DateTime.Now.AddDays(2))
            };
        }
    }
