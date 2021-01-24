	public class A
	{
		public string Filename {get; set;}
		
		public virtual void CopyProperties(object copy)
		{
			((A)copy).Filename = this.Filename;
		}
	}
	
	public class B : A
	{
		public int Number {get;set;}
		
		public override void CopyProperties(object copy)
		{
			base.CopyProperties(copy);
			((B)copy).Number = this.Number;
		}    
	}
	
	
	public class Program
	{
		
		public static void Main()
		{
			B b = new B { Filename = "readme.txt", Number = 42 };
			
			B copy = new B();
			b.CopyProperties(copy);
			
			Console.WriteLine(copy.Filename);
			Console.WriteLine(copy.Number);
		}
	}
