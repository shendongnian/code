	class Test
	{
			public int Count { get { return 1; } }
			public string this[int position] { 
				get { return String.Format("2 x {0} = {1}", 
										   position, (2*position).ToString()); }}
	}
