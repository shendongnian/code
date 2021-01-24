    static SemaphoreSlim sem = new SemaphoreSlim(1,1);
    public void Save()
    {
       SaveAsync();
       public async Task SaveAsync()
       {
            await sem.WaitAsync();
            try{
               this.customer.OrderCount = this.orders.Count();
               this.customer.OrderTotal =  this.orders.Sum(o => x.Total);
               this.customerRepo.Save();
            }finally{
               sem.Release();
            }
        }
    }
    
    public async Task LoadAsync()
    {
        await sem.WaitAsync();
        try{
            this.customer = await this.customerRepo.GetCustomerAsync(...);
            this.orders = await this.customerRepo.GetOrdersAsync(...);
        }finally{
           sem.Release();
        }
    }
    
