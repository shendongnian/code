    using System;
    using AgentOctal.WpfLib;
    
    namespace WpfDates
    {
        class MainWindowVm : ViewModel
        {
            public MainWindowVm()
            {
                Date1 = new DateTime(2017, 1, 1);
                Date2 = new DateTime(2016, 1, 1);
            }
    
            private DateTime _date1;
            public DateTime Date1
            {
                get { return _date1; }
                set
                {
                    SetValue(ref _date1, value);
                    UpdateDifference();
                }
            }
    
            private DateTime _date2;
            public DateTime Date2
            {
                get { return _date2; }
                set
                {
                    SetValue(ref _date2, value);
                    UpdateDifference();
                }
            }
    
            private int _difference;
            public int Difference
            {
                get { return _difference; }
                set
                {
                    SetValue(ref _difference, value);
                }
            }
    
            private void UpdateDifference()
            {
                Difference = (int)Math.Floor((Date1 - Date2).TotalDays);
            }
        }
    }
