      public class CustomMap : Map
    {
        private static IList<Pin> AllPins;
        public Location CenterRegion
        {
            get { return (Location)GetValue(CenterRegionProperty); }
            set { SetValue(CenterRegionProperty, value); }
        }
        public static readonly BindableProperty CenterRegionProperty =
           BindableProperty.Create(propertyName: nameof(CenterRegion), returnType: 
           typeof(Location), declaringType: typeof(CustomMap), defaultValue: null, 
           propertyChanged: (sender, oldValue, newValue) =>
           {
               CustomMap map = (CustomMap)sender;
               if (newValue is Location location)
               {
                   map.MoveToRegion(MapSpan.FromCenterAndRadius(new 
                   Position(location.Latitude, location.Longitude), 
                   Distance.FromMiles(3)));
               }
           });
        public IEnumerable CustomPins
        {
            get { return (IEnumerable)GetValue(CustomPinsProperty); }
            set { SetValue(CustomPinsProperty, value); }
        }
        public static readonly BindableProperty CustomPinsProperty =
            BindableProperty.Create(propertyName: nameof(CustomPins), returnType: 
            typeof(IEnumerable), declaringType: typeof(CustomMap), defaultValue: null, 
            propertyChanged: (sender, oldValue, newValue) =>
            {
                CustomMap map = (CustomMap)sender;
                AllPins = new List<Pin>();
                map.Pins.Clear();
                if (newValue is IEnumerable spaces)
                {
                    foreach (Pin pin in ConvertSpacesToPins(spaces))
                           map.Pins.Add(pin);
                }
                AllPins = map.Pins;
                map.OnPropertyChanged("Pins");
            });
        public static List<Pin> ConvertSpacesToPins(IEnumerable spaces)
        {
            if (spaces == null)
                return null;
            List<Pin> result = new List<Pin>();
            foreach (SpaceDto space in spaces.OfType<SpaceDto>())
            {
                double latitude = space.Latitude;
                double longitude = space.Longitude;
                string spaceTitle = space.Title;
                Position position = new Position(latitude, longitude);
                Pin pin = new Pin
                {
                    Position = position,
                    Label = spaceTitle
                };
                    result.Add(pin);
            }
            return result;
        }
    }
    
