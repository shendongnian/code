    public class SeriesService {
        private readonly ISeriesRepository repository;
    
        public SeriesService(ISeriesRepository repository
            this.repository = repository;
        }
    
        public async Task<ISeries> GetSeries(string seriesId, int channel) {
            var series = await repository.GetSeriesAsync(seriesId, channel);
            //...do some other stuff
            return series;
        }
    }
