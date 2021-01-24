    public class Country
        {
            public string Name { get; }
            public Country(string name) => Name = name;
            public static Country Afghanistan = new Country("Afghanistan");
            public static Country Albania = new Country("Albania");
            public static Country Algeria = new Country("Algeria");
            public static Country Andorra = new Country("Andorra");
            public static Country Angola = new Country("Angola");
    
            public static IList<Country> Countries = new List<Country> { Afghanistan, Albania, Algeria, Andorra, Andorra, Angola };
        }
    
        [ImplementPropertyChanged]
        public class RegistrationPageViewModel
        {
            public Country SelectedCountry { get; set; }
        }
    
        public class RegistrationPage : ContentPage
        {
            public RegistrationPage()
            {
                var vm = new RegistrationPageViewModel();
                BindingContext = vm;
                var picker = new Picker();
                foreach (var country in Country.Countries) picker.Items.Add(country.Name);
                picker.SetBinding<RegistrationPageViewModel>(Picker.SelectedIndexProperty, x => x.SelectedCountry, converter: new PickerItemsToTypeConverter<Country>(Country.Countries));
                Content = picker;
            }
        }
    
        public class PickerItemsToTypeConverter<T> : IValueConverter
        {
            private readonly IList<T> _pickerItemsList;
    
            public PickerItemsToTypeConverter(IList<T> pickerItemsList) => _pickerItemsList = pickerItemsList;
    
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var itemType = (T)value;
                return _pickerItemsList.IndexOf(itemType);
            }
    
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                var selectedIndex = value as int?;
                if (selectedIndex == null) throw new Exception("No selection");
                return _pickerItemsList[selectedIndex.Value];
            }
        }
