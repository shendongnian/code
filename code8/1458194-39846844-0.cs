    struct Test
	{
		int num;
		string str;
		public override string ToString ()
		{
			return string.Format ($"{str} | {num}");
		}
	}
