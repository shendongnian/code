    public class YourPageViewModel
    {
        private readonly ObservableCollection<VendorItemVm> _deletedVendors = new ObservableCollection<VendorItemVm>();
        public List<VendorItemVm> Vendors { get; } = new List<VendorItemVm>();
        void Add()
        {
            Vendors.Add(new VendorItemVm
            {
                IsNew = true,
                Id = new Guid(),
                UserName = "New Vendor",
            });
        }
        void Remove(VendorItemVm vendor)
        {
            Vendors.Remove(vendor);
            _deletedVendors.Add(vendor); 
        }
        async Task Load()
        {
            using(var db = new DbContext())
            {
                var vendors = db.Vendors.AsNoTracking().ToList();
                foreach(var entity in vendors)
                {
                    Vendors.Add(new VendorItemVm
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                    });
                }
            }
        }
        async Task Save()
        {
            using (var db = new DbContext())
            {
                //convert viewmodels to entities
                var newVendorsEntities = Vendors
                    .Where(v => v.IsNew)
                    .Select(v => new Vendor
                    {
                        Id = v.Id,
                        UserName = v.UserName,
                        TimeSpan = DateTime.Now,
                    })
                    .ToArray();
                //add new entities
                foreach (var vm in Vendors.Where(v => v.IsNew))
                {
                    var entity = new Vendor
                    {
                        Id = vm.Id,
                        UserName = vm.UserName,
                        TimeSpan = DateTime.Now,
                    };
                    db.Vendors.Add(vendor);
                }
                //delete removed entities:
                foreach(var vm in _deletedVendors)
                {
                    var entity = new Vendor { Id = vm.Id };
                    db.Vendors.Attach(entity);
                    db.Ventors.Remove(entity);
                    db.Vendors.Add(vendor);
                }
                await db.SaveChangesAsync();
                //reset change tracking
                foreach (var vm in Vendors) vm.IsNew = false;
                _deletedVendors.Clear();
            }
        }
    }
