	public class CantModify
	{
		private readonly IFactory _factory;
		public CantModify(IFactory factory)
		{
			_factory = factory;
		}
		 public TestMe(SomeData data)
		{
			ITreasure treasure = _factory.Get(data);
			if (treasure is BlueTreasure) ...
		else if (treasure is RedTreasure) ...
		else if (treasure is GreenTreasure) ...
	} 
