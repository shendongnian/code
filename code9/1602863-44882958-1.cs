    public class ViewModel : BaseViewModel
    {
        private string time;
        public ViewModel()
        {
            App.TimeEvent += (object o, TimeEventArgs e) =>
            {
                this.Time = e.Time;
            };
        }
        // Bind to this in your view
        public string Time
        { 
            get => this.time;
            set => this.SetProperty(ref this.time, value);
        }
    }
