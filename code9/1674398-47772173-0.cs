    public interface IExampleInterface
    {
        void WriteTo(Response response);
    }
    
    public class ExampleType : IExampleInterface
    {
        public int First;
        public int Last;
        
        public void WriteTo(Response response)
        {
            response.Write(First.ToString());
            response.Write(Last.ToString());
        }
    }
    
    public class ExampleAmount : IExampleInterface
    {
        public decimal Amount;
        public decimal TotalFee;
        
        public void WriteTo(Response response)
        {
            response.Write(Amount.ToString());
            response.Write(TotalFee.ToString());
        }
    }
    
    public class ExampleFacts : IExampleInterface
    {
        public bool TooLow;
        public bool TooHigh;
        
        public void WriteTo(Response response)
        {
            response.Write(TooLow.ToString());
            response.Write(TooHigh.ToString());
        }
    }
