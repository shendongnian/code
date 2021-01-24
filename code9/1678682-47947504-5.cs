    public class TargetClass {
        private readonly ISeriesRepository repository;
    
        public TargetClass (ISeriesRepository repository
            this.repository = repository;
        }
    
        public Task<ISeries> TargetMethod(string seriesId, int channel) {
            return repository.GetSeriesAsync(seriesId, channel);
        }
    }
