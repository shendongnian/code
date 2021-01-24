    public class SampleService
    {
         public IEnumerable<SampleModel> GetAllSamplesFromDb() 
         {
              using(var context = new SampleFactory().CreateSample())
                   return context.GetAllSamples();
         }
    }
