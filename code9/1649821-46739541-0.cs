	public class MySecondClass
	{
		public event EventHandler ChangesHappened;
		private List<MyFirstClass> first;
	
		public MySecondClass()
		{
			foreach (var f in first)
			{
				f.ChangesHappened += (s, e) => ChangesHappened?.Invoke(s, e);
			}
		}
	}
