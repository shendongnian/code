    public class BasicProject
    {
        public int p1 { get; set; }
        public int p2 { get; set; }
        public virtual IEnumerable<int> GetValues()
        {
            return new [] {p1, p2};
        }
    }
    public class AdvancedProject : BasicProject
    {
        public int p3 { get; set; }
        public int p4 { get; set; }
        public override IEnumerable<int> GetValues()
        {
            var values = new List<int>(base.GetValues());
            values.Add(p3);
            values.Add(p4);
            return values;
        }
    }
    public class AdvancedProject : BasicProject
    {
        public int p3 {get; set;}
        public int p4 {get; set;}
    }
