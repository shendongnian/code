    public class StaticClock : IClock {
        public StaticClock(DateTime now) {
             this.Now = now;
        }
        public DateTime Now { get; private set; }
    }
