    class CustomTimerTriggerBase: TimerSchedule
    {
        TimeSpan timer;
        public CustomTimerTriggerBase(string triggerConfigKey)
        {
            timer=TimeSpan.Parse(ConfigurationManager.AppSettings[triggerConfigKey]);
        }
        public override DateTime GetNextOccurrence(DateTime now)
        {
            return now.Add(timer);
        }
    }
