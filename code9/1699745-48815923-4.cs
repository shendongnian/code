    public interface ISomething
    {
        string DoSomething(Customer customer);
    }
    public class Something : ISomething
    {
        public string DoSomething(Customer customer)
        {
            // Use customer to do something
            return "done";
        }
    }
