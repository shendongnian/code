    public class UpdateWPF : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                Console.WriteLine("NotifyPropertyChanged Fired.");
            }
            private int _value = 5;
            public UpdateWPF()
            {
                Timer aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                aTimer.Interval = 1000;
                aTimer.Enabled = true;
            }
            private void OnTimedEvent(object source, ElapsedEventArgs e)
            {
                var i = Convert.ToInt32(value);
                Value = ++i;
            }
            public string Value
            {
                get => _value;
                set
                {
                    _value = value;
                    NotifyPropertyChanged();
                }
            }
        }
