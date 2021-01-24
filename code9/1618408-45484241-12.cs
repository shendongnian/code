    public class Alarm
    {
        private Func<AlarmId, bool> _theErrorCheck { get; set; }
        public Alarm(Func<AlarmId, bool> errorCheck)
        {
            this._theErrorCheck = errorCheck;
        }
        private bool PerformCheck(AlarmId theObject)
        {
            return _theErrorCheck.Invoke(theObject);
        }
    }
