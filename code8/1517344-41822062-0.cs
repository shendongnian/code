    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            times = new ObservableCollection<DayItem>();
            for (int i = 1; i < 10; i++)
            {
                times.Add(new DayItem(new DateTime(2017, 1, i), Colors.Yellow));
            }
    
            for (int i = 10; i < 20; i++)
            {
                times.Add(new DayItem(new DateTime(2016, 12, i), Colors.Green));
            }
            for (int i = 20; i < 29; i++)
            {
                times.Add(new DayItem(new DateTime(2017, 1, i), Colors.Red));
            }
        }
    
        private ObservableCollection<DayItem> times;
    
        private void MyCalendarView_SelectedDatesChanged(CalendarView sender, CalendarViewSelectedDatesChangedEventArgs args)
        {
            bool add = false;
            //If we double click the CalendarViewDayItem, the second time args.AddedDates.Count is 0
            if (args.AddedDates.Count >= 1) 
            {
                var newDate = args.AddedDates[0];
                for (int i = 0; i < times.Count; i++)
                {
                    if (newDate.Date.Year == times[i].MyDateTime.Year && newDate.Date.Month == times[i].MyDateTime.Month && newDate.Date.Day == times[i].MyDateTime.Day)
                    {
                        add = true;
                    }
                }
                if (!add)
                {
                    times.Add(new DayItem(newDate.DateTime, Colors.Green));
                }
            }
        }
    
        private void MyCalendarView_CalendarViewDayItemChanging(CalendarView sender, CalendarViewDayItemChangingEventArgs args)
        {
            var selectDay = args.Item as CalendarViewDayItem;
            for (int i = 0; i < times.Count; i++)
            {
                if (selectDay.Date.Year == times[i].MyDateTime.Year && selectDay.Date.Month == times[i].MyDateTime.Month && selectDay.Date.Day == times[i].MyDateTime.Day)
    
                    selectDay.Background = new SolidColorBrush(times[i].MyColor);
            }
        }
    }
    
    internal class DayItem
    {
        public DayItem(DateTime today, Color red)
        {
            MyDateTime = today;
            MyColor = red;
        }
    
        public Color MyColor { get; set; }
        public DateTime MyDateTime { get; set; }
    }
