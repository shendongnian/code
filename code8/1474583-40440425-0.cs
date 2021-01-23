    public IEnumerable<BusinessObjects.Customers> GetAllCustomers()
    {
        IList<BusinessObjects.Customers> customerCollection = 
            new List<BusinessObjects.Customers>();
        dataAccess.CustomerDao.GetAllCustomers();
        return customerCollection;
    }
