    public class EntityFrameworkBillService : IBillService
    {
        public AppDbContext _ctx;
        public Bill(AppDbContext db)
        {
            _ctx = db;
        }
    
        public async Task<List<Bill>> GetBills(BillGetParams billParams)
        {
             var bill = _ctx... //trying to acces an instance property in static context, does not work. and shouldn't even compile.
        }
    }
    //startup.cs:
    services.AddTransient<IBillService,EntityFrameworkBillService>()
    //Usage 
    public MyController(IBillService billService) //constructor
    {
        var dollahBills = billService.GetBills();
    }
    
     //And if you really wish this method to be there, and be lazy (but be warned: its an anti pattern)
    public class Bill
    {
        public static async Task<List<Bill>> GetBills(BillGetParams billParams)
        {
             //Make sure your ServiceProvider is available as static on Program in startup.cs.
             return Program.ServiceProvider.Resolve<IBillService>().GetBills(billParams);
        }
    }
