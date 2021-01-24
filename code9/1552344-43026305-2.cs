	public interface IInterfaceA
	{
	    object TheProperty {get; set;}
	}
	
	public interface IInterfaceA<TB> : IInterfaceA
	{
	    new TB TheProperty {get; set;}
	}
	
	public class ClassB<TA> where TA : IInterfaceA
	{
	    public TA TheProperty {get; set;}
	
	    public object ThePropertyProperty => TheProperty.TheProperty;
        // You can choose to write here either "IInterfaceA`1" or typeof(IInterfaceA<>).Name
        public Type TypeOfTB => typeof(TA).GetInterface("IInterfaceA`1").GetGenericArguments()[0];
	}
	
	public class Impl : IInterfaceA<int>
	{
		public int TheProperty { get; set; }
		
		object IInterfaceA.TheProperty
		{
			get { return TheProperty; }
			set { TheProperty = (int)value; }
		}
    }
