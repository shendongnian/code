    public class TimePicker : DateTimePicker, System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public TimePicker()
            : base()
	    {
		    this.Format = DateTimePickerFormat.Time;
	    }
        public TimeSpan Time
        {
            get
            {
                return this.Value.TimeOfDay;
            }
            set
            {
                this.Value = DateTime.Today.Add(value);
            }
        }
        protected override void OnValueChanged(EventArgs eventargs)
        {
            base.OnValueChanged(eventargs);
            if (PropertyChanged != null)
                PropertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs("Time"));
        }
    }
