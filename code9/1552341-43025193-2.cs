	public static class Helper<TB>
	{
		public static ClassB<TA> Create<TA>() where TA : IInterfaceA<TB>
		{
			return new ClassB<TA>();
		}
	
		public class ClassB<TA> where TA : IInterfaceA<TB>
		{
			TA TheProperty { get; set; }
	
			TB ThePropertyProperty => TheProperty.TheProperty;
		}
	}
