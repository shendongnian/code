    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    
    [ProtoContract]
    class Program
    {
        static void Main()
        {
            var obj = new MyData
            {
                Site = new BasicSite { BaseHost = "http://somesite.org" },
                Items =
                {
                    {"key 1", SomeType.Create(123) },
                    {"key 2", SomeType.Create("abc") },
                    {"key 3", SomeType.Create(new Whatever { Id = 456, Name = "def" }) },
                }
            };
    
            var clone = Serializer.DeepClone(obj);
            Console.WriteLine($"Site: {clone.Site}");
            foreach(var pair in clone.Items)
            {
                Console.WriteLine($"{pair.Key} = {pair.Value}");
            }
        }
    }
    
    
    [ProtoContract]
    class MyData
    {
        private readonly Dictionary<string, SomeType> _items = new Dictionary<string, SomeType>();
        [ProtoMember(1)]
        public Dictionary<string, SomeType> Items => _items;
        [ProtoMember(2)]
        public ISite Site { get; set; }
    }
    
    [ProtoContract]
    [ProtoInclude(1, typeof(SomeType<int>))]
    [ProtoInclude(2, typeof(SomeType<string>))]
    [ProtoInclude(3, typeof(SomeType<Whatever>))]
    abstract class SomeType
    {
        public object Value { get { return UntypedValue; } set { UntypedValue = value; } }
        protected abstract object UntypedValue { get; set; }
    
        public static SomeType<T> Create<T>(T value) => new SomeType<T> { Value = value };
    }
    [ProtoContract]
    class SomeType<T> : SomeType
    {
        [ProtoMember(1)]
        public new T Value { get; set; }
        protected override object UntypedValue { get => Value; set => Value = (T)value; }
        public override string ToString() => Value?.ToString() ?? "";
    }
    [ProtoContract]
    class Whatever
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        [ProtoMember(2)]
        public string Name { get; set; }
        public override string ToString() => $"{Id}, {Name}";
    }
    [ProtoContract]
    [ProtoInclude(1, typeof(BasicSite))]
    interface ISite
    {
        void SomeMethod();
    }
    [ProtoContract]
    class BasicSite : ISite
    {
        void ISite.SomeMethod() { Console.WriteLine(BaseHost); }
        [ProtoMember(1)]
        public string BaseHost { get; set; }
        public override string ToString() => BaseHost;
    }
