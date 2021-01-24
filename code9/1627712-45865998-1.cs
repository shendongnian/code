    public class YourPageViewModel
    {
        MyDbContext _myUoW;
        public ObservableCollection<Vendor> Vendors { get; } = new ObservableCollection<Vendor>();
        void Add()
        {
            var entity = new Vendor
            {
                Id = new Guid(),
                UserName = "New Vendor",
            };
            Vendors.Add(entity)
            _myUoW.Vendors.Add(entity);
        }
        void Remove(VendorItemVm vendor)
        {
            Vendors.Remove(vendor);
            _myUoW.Vendors.Attach(entity);
            _myUoW.Vendors.Add(entity);
        }
        async Task Load()
        {
            using(var db = new MyDbContext())
            {
                Vendors = db.Vendors.AsNoTracking.ToList();
                foreach(var entity in vendors) Vendors.Add(entity);
            }
            _myUoW = new MyDbContext();
            //if you want to track also changes to each vendor entity, use _myUoW to select the entities, so they will be tracked. 
            //In that case you don't need to attach it to remove
        }
        async Task Save()
        {
            //add new entities and delete removed entities
            _myUoW.SaveChanges();
            //reset change tracking
            _myUoW.Dispose();
            _myUoW = new MyDbContext();
        }
    }
