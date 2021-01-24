    public class SampleService
    {
         private ISampleFactory factory;
    
         public SampleService(ISampleFactory factory) => this.factory = factory;
    
         public IEnumerable<SampleModel> GetAllSamplesFromDb()
         {
              using(var context = factory.CreateSample())
                  return context.GetAllSamples();
         {
    }
