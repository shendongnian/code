    public class Service {
        ITimeDistance timeDistance
        public Service(ITimeDistance timeDistance) {
            this.timeDistance = timeDistance;
        }
        public ITimeDistance TimeDistance { get { return timeDistance; } }
    }
