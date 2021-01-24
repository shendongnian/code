    class DAL
    {
        public CustomerTO GetCustomers()
        {
            var customers= //LINQ To get customers 
            var customerTO = Mapping(customer);
            return customerTO;
        }
        //However, this mapping glue in some internal class to retain SOLID principles
        private CustomerTO Mapping(Customer custEntity)
        {
            var custTO = _appMapper.Map(custEntity);
            var str = JsonConvert.Serialize(custTO.CustomerData);
            custTO.CustomerData = JsonConvert.Deserialize(str);
            return custTO;
        }
    }
