    public interface IAuditable
    {
        string AuditInfo { get; }
    }
    public class Foo : IAuditable
    {
        public string FooProp1 { get; set; }
        public Bar Bar { get; set; }
    
        [NotMapped]
        public string AuditInfo
        {
            get { return Bar?.BarProp1; }
        }
    }
