    public class SummaryDto
    {
        public string Name {get; set;};
        public string GenericName {get; set; }
        public Dictionary<int,int> Data {get; } = new Dictionry<int,int>();
    }
