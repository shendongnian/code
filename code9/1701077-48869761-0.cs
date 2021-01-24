    public class SampleContext : ISampleRepository
    {
         public IEnumerable<SampleModel> GetAllSamples() => dbConnection.ExecuteQuery(query); // Dapper syntax, but you get the idea
  
         // Implement Dispose
    }
    public interface ISampleRepository : IDispose
    {
         IEnumerable<SampleModel> GetAllSamples();
    }
