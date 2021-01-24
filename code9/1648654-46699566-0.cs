    public class BaseClass
	{
		 protected virtual void OnlyMeOrChildrenCanDoAction()
		 {
			 // leave empty as current class is structural/conceptual
			 // but child instances may need it
		 }
	}
	
	public class DerivedClass : BaseClass
	{
		public new void OnlyMeOrChildrenCanDoAction()
		{
			Console.WriteLine("This is public.");
		}
	}
	
	public class Program
	{
		public static void Main()
		{
			var b = new BaseClass();
			//b.OnlyMeOrChildrenCanDoAction(); //Will not compile
			
			var d = new DerivedClass();
			d.OnlyMeOrChildrenCanDoAction();  //Look! It's public!
		}
	}
