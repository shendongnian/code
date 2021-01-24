    public CustomerAccountsController : ApiController
    {
        private CustomerAccountService _customerAccountService; // lives in application layer project
        public CustomerAccountsController() 
        { 
            // di stuff 
        }
        public HttpResponseMessage PutCancelAccount( int accountId )
        {
           // exception handling + logging
           _customerAccountService.CancelAccount(accountId);
          // return status code if success, or if an exception
        }
    }
    public OrderController : ApiController
    {
        private OrderService _orderService; // lives in application layer project
        public OrderController()
        { //di stuff
        }
        public HttpResponseMessage PostCreateOrder(CreateOrderRequest createOrderRequest) 
        {
            // exception handling + logging
            _orderService.TakeOrder(createOrderRequest);
            // return status code if success, or if an exception
        }
    }
