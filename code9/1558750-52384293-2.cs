    public class CustomMapSampleViewModel : BindableBase
        {
            public Location CurrentLocation { get; set; }
            public SpaceDto Spaces { get; set; }
            public CustomMapSampleViewModel()
            {
            }
            public async Task OnNavigatedToAsync(NavigationParameters parameters)
            {
                Location CurrentLocation = await Geolocation.GetLastKnownLocationAsync();
                List<SpaceDto> Spaces = new List<SpaceDto> { 
                new SpaceDto { Latitude = 45.6892 , Longitude = 51.3890, Title = "X"  }, 
                new SpaceDto { Latitude = 45.6891, Longitude = 51.3890, Title = "Y" }, 
                new SpaceDto { Latitude = 45.6888, Longitude = 51.3890, Title = "Z" } };
            }
        }
    
        public class SpaceDto
        {
            public string Title { get; set; }
            public virtual double Latitude { get; set; }
            public virtual double Longitude { get; set; }
        }
