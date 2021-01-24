	public interface IInterfaceA<T>
	{
	    T TheProperty {get; set;}
	}
	
	public class ClassB<TA, TB> where TA : IInterfaceA<TB>
	{
	    TA TheProperty {get; set;}
	
	    TB ThePropertyProperty => TheProperty.TheProperty;
	}
