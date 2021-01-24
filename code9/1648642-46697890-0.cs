        private readonly IVehicleRepository _vehicleRepository;
    
        public VehicleModelController()
        {
            _vehicleRepository = new VehicleRepository(new VehicleDbContext());
        }
    
       
        public ActionResult Create()
        {
            var vm=new VehicleModelViewModel();
            vm.Makes = GetMakeOptions();
            return View(vm);
        }
        private List<SelectListeItem> GetMakeOptions()
        {
          return this._vehicleRepository.AllMakes
                     .Select(x=>new SelectListItem { Value=x.Id.ToString(), 
                                                     Text=x.Name})
                     .ToList();
        }  
    }
