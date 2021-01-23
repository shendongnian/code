    class Program
    {
        static void Main(string[] args)
        {
            var t = new ClockTimer();
            t.Start();
            var date = t.TimerTimesInstance.Start; // getter Ok
            t.TimerTimesInstance.Start = DateTime.Now; // Error! setter denied
        }
    }
    public class ClockTimer
    {
        public interface ITimerTimes
        {
            DateTime? Start { get; }
        }
        private class TimerTimes : ITimerTimes
        {
            public DateTime? Start { get; set; }
        }
        private TimerTimes m_TimerTimes = null;
        public virtual void Start()
        {
            m_TimerTimes = new TimerTimes();
            m_TimerTimes.Start = DateTime.Now;  //Property Start is assessible here
        }
        public ITimerTimes TimerTimesInstance { get { return m_TimerTimes; } }
    }
