    public sealed partial class MainPage : Page
    {
        private MyViewModel ViewModel;
        private DateTime today;
        private DateTime minDate;
        private DateTimeOffset maxDate;
        public MainPage()
        {
            this.InitializeComponent();
            // Keep these for reference
            this.today = DateTime.Now.Date;
            this.minDate = new DateTime(today.Year, today.Month, 1);
            this.maxDate = minDate.AddMonths(1);
            // Create our viewmodel
            ViewModel = MyViewModel.Generate(minDate.Date, maxDate.Date);
            Calendar.MinDate = minDate;
            Calendar.MaxDate = maxDate;
            // Add data for the next three days - will be shown when page loads
            ViewModel.Dates[today.AddDays(1)].Add(Colors.Red);
            ViewModel.Dates[today.AddDays(2)].Add(Colors.Purple);
            ViewModel.Dates[today.AddDays(2)].Add(Colors.Blue);
            ViewModel.Dates[today.AddDays(3)].Add(Colors.Green);
        }
        private void CalendarView_DayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            // When the DayItem in the calendar is loaded
            var itemDate = args?.Item?.Date.Date ?? DateTime.MinValue;
            if (ViewModel.Dates.ContainsKey(itemDate))
            {
                // Set the datacontext for our custom control
                // - Which does support 2way binding :)
                args.Item.DataContext = ViewModel.Dates[itemDate];
            }
        }
        private void AddEventClicked(object sender, RoutedEventArgs e)
        {
            var rand = new Random();
            var randomColor = Color.FromArgb(
                                             255,
                                             (byte) rand.Next(0, 254),
                                             (byte)rand.Next(0, 254),
                                             (byte)rand.Next(0, 254));
            var randomDay = rand.Next(1, 29);
            var randDateInMonth = new DateTime(today.Year, today.Month, randomDay);
            if (ViewModel.Dates.ContainsKey(randDateInMonth))
            {
                ViewModel.Dates[randDateInMonth].Add(randomColor);
            }
        }
    }
    public class MyViewModel
    {
        // The VM really just holds this dictionary
        public Dictionary<DateTime, DensityColors> Dates { get; }
        private MyViewModel()
        {
            this.Dates = new Dictionary<DateTime, DensityColors>();
        }
        // Static constructor to limit the dates and populate dictionary
        public static MyViewModel Generate(DateTime minDate, DateTime maxDate)
        {
            var generated = new MyViewModel();
            for (var i = 0; i < (maxDate - minDate).TotalDays; i++)
            {
                generated.Dates.Add(minDate.AddDays(i), new DensityColors());
            }
            
            return generated;
        }
    }
    public class DensityColors : ObservableCollection<Color>, INotifyPropertyChanged
    {
        // Properties that expose items in underlying OC
        public Color FirstColor => Items.Any() ? Items.First() : Colors.Transparent;
        public Color SecondColor => Items.Count > 1 ? Items.Skip(1).First() : Colors.Transparent;
        public Color ThirdColor => Items.Count > 2 ? Items.Skip(2).First() : Colors.Transparent;
        public Color FourthColor => Items.Count > 3 ? Items.Skip(3).First() : Colors.Transparent;
        public Color FifthColor => Items.Count > 4 ? Items.Skip(4).First() : Colors.Transparent;
        protected override void InsertItem(int index, Color item)
        {
            base.InsertItem(index, item);
            // Hacky forcing of updating UI for all properties
            OnPropertyChanged(nameof(FirstColor));
            OnPropertyChanged(nameof(SecondColor));
            OnPropertyChanged(nameof(ThirdColor));
            OnPropertyChanged(nameof(FourthColor));
            OnPropertyChanged(nameof(FifthColor));
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ColorBrushConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Color)
            {
                return new SolidColorBrush((Color)value);
            }
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
