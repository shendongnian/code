    public class BaseCustomer<TRep>
    {
        protected TRep Reputation;
    }
    public class CustomerDeluxe : BaseCustomer<ushort>
    {
    }
    public class Customer : BaseCustomer<byte>
    {
       
    }
