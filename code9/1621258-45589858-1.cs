    class CustomerService : ICustomerService
    {
        private IUnitOfWork unitOfWork;
        public CustomerService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public void AddCustomer(Customer customer)
        {
            this.unitOfWork.CustomerRepository.Add(customer);
            this.unitOfWork.Save();
            // Call REST here
        }
        public void DeleteCustomer(int customerId)
        {
            this.unitOfWork.CustomerRepository.DeleteById(customerId);
            this.unitOfWork.Save();
            // Call REST here
        }
    }
