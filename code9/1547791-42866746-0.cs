    public class GetData {
        public async Task<IEnumerable<object>> GetDataAsync(DateTime startDate, DateTime endDate) {
            var daysPerChunk = 28;
            var totalChunks = (int)Math.Ceiling((endDate - startDate).TotalDays / daysPerChunk);
            var chunks = Enumerable.Range(0, totalChunks);
            var dataTasks = chunks.Select(chunkIndex => {
                var start = startDate.AddDays(chunkIndex * daysPerChunk);
                var end = new DateTime(Math.Min(start.AddDays(daysPerChunk).Ticks, endDate.Ticks));
                return ExternalWebService.GetListByPeriodAsync(from: start, to: end);
            });
            var results = await Task.WhenAll(dataTasks);
            var data = results.SelectMany(_ => _);
            return data.ToList();
        }
    }
    public class ExternalWebService {
        private static HttpClient Client {
            get;
        } = new HttpClient();
        public async static Task<IEnumerable<object>> GetListByPeriodAsync(DateTime from, DateTime to) {
            var response = await Client.GetAsync("GetListByPeriodFromToUri");
            if (response != null && response.IsSuccessStatusCode) {
                using (var stream = await response.Content.ReadAsStreamAsync()) {
                    using (var reader = new StreamReader(stream)) {
                        var str = reader.ReadToEnd();
                        return JsonConvert.DeserializeObject<IEnumerable<object>>(str);
                    }
                }
            }
            return Enumerable.Empty<object>();
        }
    }
