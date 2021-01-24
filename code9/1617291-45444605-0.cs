    class A
    {
        public List<int> QuantityList { get; set; } = new List<int>();
    }
    class B
    {
        public int Quantity { get; set; }
    }
    var a = new A();
    a.QuantityList.Add(5);
    Mapper.Initialize(c => c.CreateMap<A, B>().ForMember(x => x.Quantity, y => y.MapFrom(z => z.QuantityList.First() == 0 ? 1 : z.QuantityList.First())));
    var b = Mapper.Map<A, B>(a);
