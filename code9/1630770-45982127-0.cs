    public sealed class MyClassMap : CsvClassMap<MyClass>
    {
        public MyClassMap()
        {
            Map( m => m.Id );
            Map( m = > m.Name );
        }
    }
