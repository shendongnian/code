    public class ClockTimer {
    
        private class TimerTimes {
            public DateTime? Start { get; set; }
        }
        public ClockTimer() {
            var timerTimes = new TimerTimes();
            timerTimes.Start = DateTime.Now;
        } 
    }
