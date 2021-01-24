    public class Customer
    {
      public bool Active { get; set; }
    }
    static void InsertCustomer()
    {
      var customer = connect.QueryFirst<Customer>("select 1 active from dual"); // this works
      connect.Execute(@"insert into customers(active) values(:active)", customer.ConvertToDynamicParameters()); // this doesn't
    }
