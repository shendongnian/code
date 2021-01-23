    public class Service : IService
    {
        public Task<double> GetDataAsync(int id)
        {
            return Task.FromResult(1.0);
        }
    } 
