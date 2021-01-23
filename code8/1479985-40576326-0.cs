    public class ViewModelFactory : IViewModelFactory
    {
        public DashboardViewModel CreateDashboardViewModel()
        {
            return new DashboardViewModel
            {
                LastFed = "unknown",    
                WaterTemperatureTile = CreateSensorTileViewModel()
            };
        }
        public SensorTileViewModel CreateSensorTileViewModel()
        {
            return new SensorTileViewModel
            {
                Title = "Water temperature",
                ColorCssClass = "panel-primary",
                IconCssClass = "fa-sliders"
            };
        }
    }
