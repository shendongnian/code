    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlarmView : TabbedPage {
        private AlarmModel CurrentAlarm;
        //if user create a new alarm then no argument pass in constructor
        public AlarmView (AlarmModel alarm = null) {
            InitializeComponent ();
            if (alarm != null) {
                this.CurrentAlarm = alarm;                         
            }
            BindingContext = CurrentAlarm ?? new AlarmModel(); //Must have a model to bind to.
        }
    }
