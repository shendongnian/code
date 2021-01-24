    public interface IService
    {
        Customer Serve(Guid RecordId);
    }
    public class Service : IService
    {
        private readonly ISomething something;
        public Service(ISomething something)
        {
            if (something == null)
                throw new ArgumentNullException(nameof(something));
            this.something = something;
        }
        public Customer Serve(Guid RecordId)
        {
            // No need to inject dependencies here
            Customer obj1 = new Customer();
            obj1.ID = 2;
            obj1.Name = "xyz";
            something.DoSomething(obj1);
            return obj1;
        }
    }
