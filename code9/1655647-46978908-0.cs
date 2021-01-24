    [Table("DBInformation")]
    public class FooBar
    {
        #region Properties
        [ExplicitKey] // Use this attribute if your ID field is not automatically generated, (identity)
        public string Id { get; set; }
        public string Foo { get; set; }
        public string Bar { get; set; }
        ...
    }
