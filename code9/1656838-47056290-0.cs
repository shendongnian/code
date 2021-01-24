    public class DatabaseModel
    {
        public int RIT_TYPE { get; set; }
        public string RIT_NAME { get; set; }
        public int RIT_DEF_TYPE { get; set; }
        public int RIT_DEF_CODE { get; set; }
    }
    public class TypeDTO
    {
        public long Type { get; set; }
        public string Name { get; set; }
        public byte DefType { get; set; }
        public byte DefCode { get; set; }
        public Dictionary<int, int> SumOfEachType = new Dictionary<int, int>();
    }
