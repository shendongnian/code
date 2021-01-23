    public class ClockTimer
    {
        public abstract class TimerTimes
        {
            public DateTime? Start { get; protected set; }
        }
        private class TimerTimesImpl : TimerTimes
        {
            public void SetStart(DateTime? startTime)
            {
                Start = startTime;
            }
        }
        private TimerTimesImpl m_TimerTimes = null;
        public virtual void Start()
        {
            m_TimerTimes = new TimerTimesImpl();
            m_TimerTimes.SetStart(DateTime.Now);  //Property Start is assessible through setter now
        }
    }
