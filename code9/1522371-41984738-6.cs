	public class Astore : A
	{
		public A GetInstanceOfA()
		{
			return base.GetInstance();
		}
	}
	public class A
	{
		protected A() { }
		protected A GetInstance()
		{
			return new A();
		}
		public void MemberFunctionOfA()
		{
			// blah blah...
		}
	}
    //Usage
	public class ConsumerClass
	{
		public void Test()
		{
			var a = new A(); // Compile error
			a = new Astore().GetInstanceOfA();
            a.MemberFunctionOfA();
		}
	}
