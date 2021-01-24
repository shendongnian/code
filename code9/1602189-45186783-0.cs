        public override void ViewDidLoad()
        {
            SFCalendar calendar = new SFCalendar();
            base.ViewDidLoad();
            calendar.Frame = new CGRect(0, 0, View.Frame.Width, View.Frame.Height);
            SFMonthViewSettings month = new SFMonthViewSettings();
            month.BorderColor = UIColor.Red;
            calendar.MonthViewSettings = month;
            View.AddSubview(calendar);
           
        }
