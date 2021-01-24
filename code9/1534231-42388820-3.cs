    public class Bill
    {
        public AppDbContext _ctx;
        public Bill(AppDbContext db)
        {
            _ctx = db;
        }
    
        public static async Task<List<Bill>> LoadBills(BillGetParams billParams)
        {
             var bill = _ctx... //trying to acces an instance property in static context, does not work. and shouldn't even compile.
        }
    }
