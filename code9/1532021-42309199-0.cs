    public class FooModel
    {
        [DefaultValue(0)]
        public int FooId { get; set; } = 0;
        [DefaultValue("")]
        public string Description { get; set; } = "";
        public List<BarModel> Bars { get; set; }
        public bool ShouldSerializeBars() { return Bars != null && Bars.Any(); }
    }
