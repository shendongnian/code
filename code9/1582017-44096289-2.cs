    public class SampleModelService
    {
        public Task<IEnumerable<SampleModel>> GetDataAsync()
        {
            var data = new List<SampleModel>();
            data.Add(new SampleModel
            {
                Title = "Lorem ipsum dolor sit 1",
                Description = "Lorem ipsum dolor sit amet",
                Symbol = Symbol.Globe
            });
            data.Add(new SampleModel
            {
                Title = "Lorem ipsum dolor sit 2",
                Description = "Lorem ipsum dolor sit amet",
                Symbol = Symbol.MusicInfo
            });
        
            return Task.FromResult<IEnumerable<SampleModel>(data); 
         }
    }
