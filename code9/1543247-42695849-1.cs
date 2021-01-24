    public class MyController
    {
        [HttpGet]
        public ViewResult GetCustomer(int customerID)
        {
            var myViewModel = new CustomerViewModel();
            var myService = new MyServiceLayer();
    
            var myCustomerDetails = myService.GetCustomerDetails(customerID);
    
            myViewModel.Customer = myCustomerDetails;
    
            return View("CustomerDetails", myViewModel);
        }
    }
    
    public class CustomerViewModel
    {
        public CustomerDomainObject Customer { get; set; }
    }
    
    
    public class CustomerDomainObject
    {
        public string Name {get;set;}
    }
    
    public class MyServiceLayer
    {
        public CustomerDomainObject GetCustomerDetails(int customerID)
        {
            var myCustomer = new CustomerDomainObject();
            var dataLayer = new MyDataLayer();
            var myCustomerData = dataLayer.GetCustomerDetails(customerID);
    
            var myDataRow = myCustomerData.Tables[0].Rows[0];
            myCustomer.Name = myDataRow["Name"].ToString();
    
            return myCustomer;
        }
    }
    
    public class MyDataLayer
    {
        public DataSet GetCustomerDetails(int customerID)
        {
            //Execute proc etc...
            return new DataSet();
        }
    }
