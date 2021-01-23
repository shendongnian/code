    public IEnumerable<BusinessObjects.Customers> GetAllCustomers()
    {
        IList<BusinessObjects.Customers> customerCollection = 
            new List<BusinessObjects.Customers>(); // ← An empty list
        dataAccess.CustomerDao.GetAllCustomers();  // ← Just executed but didn't use anywhere
        return customerCollection;                 // ← The empty list you created at first
    }
