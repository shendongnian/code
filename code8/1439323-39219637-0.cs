        public static List<Customer> GetCustomer(int customerID)
            {
                List<Customer> CusList = new List<Customer>();
                Customer customer = new Customer();
                .... // Before returning,
                CusList.Add(customer);
                return CusList;
            }
