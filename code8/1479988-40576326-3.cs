    public class ViewModelService : IViewModelService
    {
        private readonly ISensorDataService sensorDataService;
        private readonly IUrlHelper urlHelper;
    
        public ViewModelService(
                   ISensorDataService sensorDataService, 
                   IUrlHelperFactory urlHelperFactory, 
                   IActionContextAccessor actionContextAccessor)
        {
            sensorDataService = sensorDataService;
            urlHelper = urlHelperFactory.GetUrlHelper(actionContextAccessor.ActionContext);
        }
    
        public DashboardViewModel GetDashboardViewModel()
        {
            var model = ViewModelFactory.CreateDashboardViewModel();
            var url = urlHelper.Action("GetWaterTemperatureChart", "History")
            var waterTemp = sensorDataService.GetWaterTemperatureFahrenheit().Value;
            model.Value = waterTemp;
            model.url = url;
            return model;
        }
    }
