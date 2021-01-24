    [MetadataType(typeof(Table1MetaData))]
    public partial class Table1
    {
        private class Table1MetaData
        {
            [MaxLength(20)]
            public string Foo { get; set; }
        }
    }
