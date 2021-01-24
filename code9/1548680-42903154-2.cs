    public class A { public B MemberB { get; set; }}
    public class B { public string Name { get; set; }}
    List<A> listt = new List<A>{
                new A{ MemberB = new B{Name ="a"}},
                new A{ MemberB = new B{Name ="b"}},
                new A{ MemberB = new B{Name ="u"}},
                new A{ MemberB = new B{Name ="l"}},
                new A{ MemberB = new B{Name ="i"}}
    };
    var rr = OrderByQuery(listt.AsQueryable(), "MemberB.Name", SortDirection.Ascending).ToList();
