    static SemaphoreSlim sem = new SemaphoreSlim(1,1);
    
    public static async Task<IDisposable> LockAsync(){
        await sem.WaitAsync();
        return Disposable.Create(()=>sem.Release());
    }
    public void Save()
    {
       SaveAsync();
       public async Task SaveAsync()
       {
            using(await LockAsync()){
               this.customer.OrderCount = this.orders.Count();
               this.customer.OrderTotal =  this.orders.Sum(o => x.Total);
               this.customerRepo.Save();
            }
        }
    }
    
    public async Task LoadAsync()
    {
        using(await LockAsync()){
            this.customer = await this.customerRepo.GetCustomerAsync(...);
            this.orders = await this.customerRepo.GetOrdersAsync(...);
        }
    }
