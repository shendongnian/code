	public class A { }
	public class B : A { }
	public class C : A { }
	public interface IContainer
	{
		A[] value { get; }
	}
	
	class BContainer : IContainer { public B[] value { get; set; } A[] IContainer.value { get { return this.value; } } }
	class CContainer : IContainer { public C[] value { get; set; } A[] IContainer.value { get { return this.value; } } }
	
	void ProcessValue(IEnumerable<A> arg) { }
	
	void ExtractValue(IContainer container)
	{
		ProcessValue(container.value);
	}
