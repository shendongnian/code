    public interface IService
    {
        Task<double> GetDataAsync(int id);
    }
    public class Service : IService
    {
        public async Task<double> GetDataAsync(int id)
        {
            await Task.Delay(1000);
            return 1.0;
        }
    }
