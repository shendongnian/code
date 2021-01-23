        namespace Business.DataAccessAbstractions
        {
            public interface ICustomerDataAccess
            {
                List<ICustomer> Load(int topAmount);
            }
        }
 
    4.2 Implement `ICustomerService` which use abstractions of `ICustomerDataAccess`
    public class CustomerService : ICustomerService
    {
        private DataAccessAbstractions.ICustomerDataAccess _dataAccess;
        public CustomerService(DataAccessAbstractions.ICustomerDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public IEnumerable<ICustomer> LoadTop50()
        {
            const int TOP_NUMBER = 50;
            return _dataAccess.Load(TOP_NUMBER);
        }
    }
