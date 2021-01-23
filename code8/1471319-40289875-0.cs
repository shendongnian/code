	public static class Extension
	{
		public static bool IsFull(this Array self)
		{
			for (int i = 0; i < self.Length; i++)
			{
				var t = self.GetValue(i);
				var arrT = t as Array;
				var tt = t as MyType;
				if (t == null || (arrT != null && !arrT.IsFull()) || (tt != null && !tt.IsFull()))
				{
					return false;
				}
			}
			return true;
		}
	}
