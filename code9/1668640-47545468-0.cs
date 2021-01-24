    public class Test {
        public DateTime A { get; set; }
        public Int32 B { get; set; }
        public Int64 C { get; set; }
        public DateTime? D { get; set; }
    }
    
    ...Main...
            var @switch = new Dictionary<Type, Action> {
                { typeof(DateTime), () => Console.WriteLine("DateTime") },
                { typeof(Int32), () => Console.WriteLine("Int32") },
                { typeof(Int64), () => Console.WriteLine("Int64") },
                { typeof(DateTime?), () => Console.WriteLine("DateTime?") },
            };
            foreach (var prop in typeof(Test).GetProperties()) {
                @switch[prop.PropertyType]();
            }
