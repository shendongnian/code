    public void CreateContract(User user,Contract contract)
    {
        this.dbContext.Users.Add(user);
        this.dbContext.Contracts.Add(contract);  
     
        this.dbContext.SaveChanges();
    }
 
