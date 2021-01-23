    public interface IOrderService
        {
            IEnumerable<CustomerOrderDto> GetOrders();
        }
     public IEnumerable<CustomerOrderDto> GetOrders()
        {
            List<CustomerOrderDto> customerOrderList = new List<CustomerOrderDto>();
    
            foreach (var item in customerOrderList)
            {
                CustomerOrderDto customerOrder = new CustomerOrderDto();
                //fields mapping
    
                customerOrderList.Add(customerOrder);
            }
    
    
            return customerOrderList;
        }
