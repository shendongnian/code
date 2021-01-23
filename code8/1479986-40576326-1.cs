    public class ViewModelService : IViewModelService
    {
        private readonly ISensorDataService sensorDataService;
        private readonly IUrlHelper urlHelper;
        private readonly IViewModelFactory viewModelFactory;
    
        public ViewModelService(
                   ISensorDataService sensorDataService, 
                   IUrlHelperFactory urlHelperFactory, 
                   IViewModelFactory factory, 
                   IActionContextAccessor actionContextAccessor)
        {
            sensorDataService = sensorDataService;
            viewModelFactory = factory;
            urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }
    
        public DashboardViewModel GetDashboardViewModel()
        {
            var model = factory.CreateDashboardViewModel();
            var url = urlHelper.Action("GetWaterTemperatureChart", "History")
            var waterTemp = sensorDataService.GetWaterTemperatureFahrenheit().Value;
            model.Value = waterTemp;
            model.url = url;
            return model;
        }
    }
