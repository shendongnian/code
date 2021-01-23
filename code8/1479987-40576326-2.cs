    public static class ViewModelFactory
    {
        public static DashboardViewModel CreateDashboardViewModel()
        {
            return new DashboardViewModel
            {
                LastFed = "unknown",    
                WaterTemperatureTile = CreateSensorTileViewModel()
            };
        }
        public static SensorTileViewModel CreateSensorTileViewModel()
        {
            return new SensorTileViewModel
            {
                Title = "Water temperature",
                ColorCssClass = "panel-primary",
                IconCssClass = "fa-sliders"
            };
        }
    }
