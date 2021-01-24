    public class UnitReference
    {
        readonly long unitReferenceId;
        public UnitReference(long unitReferenceId)
        {
            this.unitReferenceId = unitReferenceId;
        }
        public long UnitReferenceId { get { return unitReferenceId; } }
        public List<Unit> Units { get; set; }
    }
    public class Unit
    {
        [JsonProperty("Unit")]
        public string UnitValue { get; set; }
        public long Scale { get; set; }
    }
    public class Widget
    {
        public string Name { get; set; }
        public UnitReference UnitReference { get; set; }
    }
