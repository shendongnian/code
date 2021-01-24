    public void CreateStatus(Status enums, string userName)
    {
         Customer t = new Customer();
         t.Name = userName;
         t.Status = enums.Success.ToString();
    
    }
