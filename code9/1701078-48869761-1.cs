    public class SampleFactory : ISampleFactory
    {
         public ISampleRepository CreateSample() => new SampleContext();
    }
    
    public interface ISampleFactory
    {
         ISampleRepository CreateSample();
    }
