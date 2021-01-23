        namespace Business.DataAccessAbstractions
        {
            public interface ICustomerDataAccess
            {
                List<ICustomer> Load(int topAmount);
            }
        }
