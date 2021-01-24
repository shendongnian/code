	public class DerivedClass1 : BaseClass
	{
		protected DerivedClass1 Parent
		{
			get
			{
				return Node.GetParent(this);
			}
		}
	}
