    public delegate void AlarmReadyToRing(object sender, object alarm);
    public class AppointmentViewer
    {
        public event AlarmReadyToRing AlarmIsReady;
        public List<object> Appointments { get; private set; }
        private Timer _AlarmClock;
        public AppointmentViewer()
        {
            LoadAppointmentsFromStorage();
            _AlarmClock = new Timer(TriggerAlarms, null, 0, (int)TimeSpan.FromSeconds(1).TotalMilliseconds);
        }
        private void TriggerAlarms(object state)
        {
            // Find all alarms that should be going off now
            // FindAppointments(x=>x.StartTime == Datetime.Now)
            var readyAlarms = FindAppointments();
            foreach (var alarm in readyAlarms)
            {
                AlarmIsReady?.Invoke(this, alarm);
            }
        }
        public void SaveAppointment(object appt)
        {
            // Save appointment logic
            Appointments.Add(appt);
        }
        public void LoadAppointmentsFromStorage()
        {
            // Load appointments from local storage or other
            Appointments = new List<object>();
        }
        public List<object> FindAppointments(Func<object, bool> search)
        {
            var found = Appointments.Where(search);
            return found;
        }
    }
    public class SomeOtherClass
    {
        private static AppointmentViewer ApptViewer { get; set; } = new AppointmentViewer();
        public SomeOtherClass()
        {
            // Register for event
            ApptViewer.AlarmIsReady += DoSomething;
        }
        private void DoSomething(object sender, object alarm)
        {
            // Here is the incoming alarm that needs to be going off
            // Apply logic for app to display alarm
        }
    }
