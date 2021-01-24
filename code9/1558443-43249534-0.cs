    public interface IStatisticsModule {
        bool Enabled { get; }
        void Save(object stuff);
        // whatever else it can do
    }
    class NullStatistics : IStatisticsModule {
        public bool Enabled => false;
        public void Save(object stuff) {
            // do nothing or throw
        }
    }
    class RealStatisticsModule : IStatisticsModule {
        public bool Enabled => true;
        public void Save(object stuff) {
            // save
        }
    }
    public class DataMatrixModule {
        private readonly IStatisticsModule _stats;
        public DataMatrixModule(IStatisticsModule stats) {
            _stats = stats;
        }
        public void SomeOperation() {
            if (_stats.Enabled)
                _stats.Save(null);
        }
    }
