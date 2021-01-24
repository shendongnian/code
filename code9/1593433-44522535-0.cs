    internal class FooBarQueryModel 
    {
        public string Zebra { get; set; }
        public int One { get; set; }
        public int Two { get; set; }
    }
    conn.Query<FooBarQueryModel>(sql).Select(qm => new Foo(new Bar(qm.One, qm.Two), qm.Zebra));
