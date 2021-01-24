    public class A {  }
    public class B { public int Index { get;set; } }
    var colA = new List<A>();
	var colB = colA.Select((a, ix) => 
	{
	   var b = Mapper.Map<B>(a);
	   b.Index = ix + 1;
	   return b;
	});
