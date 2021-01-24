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
    public MyControllect(IBillService billService) //constructor
    {
        var dollahBills = billService.GetBills();
    }
