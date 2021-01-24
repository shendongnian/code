    public class CustomerData : ICustomerData
    {
        CustomerName GetCustomerName(CustomerNumber number)
        {
            return CustomerData.GetCustomerName(number);
        }
    
        public CustomerData()
        {
            CustomerData = new WebService.WebServiceClient ();
        }
        private WebService.WebServiceClient CustomerData;
    }
    public class DelegatedCustomerData : ICustomerData
    {
        public Func<CustomerNumber,CustomerName> GetCustomerName {get;set;}
        
        CustomerName ICustomerData.GetCustomerName(CustomerNumber number) => GetCustomerName(number);
    }
