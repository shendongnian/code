    using System;
    public interface IB
    {
		string P { get; }
    }
    public interface IC : IB
    {
        new string P { get;}
    }
    public class B : IB
    {
        public string P => "B";
    }
    public class C : B, IC
    {
        public new string P => "C";
    }
    public class D1 : C  // NO IC
    {
	    public new string P => "D1";
    }
    public class D2 : C, IC // YES IC
    {
	    public new string P => "D2";
    }
    public class Program
    {
        static public void Main(string[] args)
        {
            var d1 = new D1();
			var d2 = new D2();
			Console.WriteLine(((B)d1).P);
			Console.WriteLine(((C)d1).P);
			Console.WriteLine(((IB)d1).P);
			Console.WriteLine(((IC)d1).P);
			Console.WriteLine(((D1)d1).P);
			Console.WriteLine(((B)d2).P);
			Console.WriteLine(((C)d2).P);
			Console.WriteLine(((IB)d2).P);
			Console.WriteLine(((IC)d2).P);
			Console.WriteLine(((D2)d2).P);
        }
    }
