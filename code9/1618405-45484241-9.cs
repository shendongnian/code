    public class Alarm
    {
        private Func<AlarmId, bool> _theErrorCheck { get; set; }
        private AlarmId _theObject { get; set; }
        public Alarm(Func<AlarmId, bool> errorCheck, AlarmId obj)
        {
            this._theErrorCheck = errorCheck;
            this._theObject = obj;
        }
        private bool PerformCheck()
        {
            return _theErrorCheck.Invoke(_theObject);
        }
    }
