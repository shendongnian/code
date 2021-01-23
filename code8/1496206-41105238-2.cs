    public class LocationSelector : ViewComponent
    {
        private readonly ILocationService locationsService;
        private readonly  ICache cache;
        public LocationSelector(ILocationService locationService,ICache cache)
        {
            this.locationsService = locationService;
            this.cache = cache;
        }
    
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var locationManager = new LocationSelectorViewModel();
            var areas = await this.cache.Get(CacheKey.Statuses, () =>
                                                       this.locationsService.GetAreas(),360);
            locationManager.Areas = areas;
           
            return View("Default", locationManager);
        }
    }
