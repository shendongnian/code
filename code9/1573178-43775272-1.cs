    public interface IAlphaModel
    {
        string SomeField { get; set; }
    }
    public interface IBetaModel
    {
        int AnotherField { get; set; }
    }
    public interface ISomeRequest : IAlphaModel, IBetaModel
    {
        bool YetAnotherField { get; set; }
        
    }
    class SomeRequest : ISomeRequest
    {
        public string SomeField { get; set; }
        public int AnotherField { get; set; }
        public bool YetAnotherField { get; set; }
    }
    public interface IAnotherRequest : IBetaModel
    {
        long TheUltimateField { get; set; }
        
    }
    class AnotherRequest : IAnotherRequest
    {
        public int AnotherField { get; set; }
        public long TheUltimateField { get; set; }
    }
