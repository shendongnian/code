		public List<Type> Ancestors(Type any)
		{
			var result = new List<Type>();
			result.Add(any);
			while (any != typeof(object))
			{
				any = any.BaseType;
				result.Insert(0, any);
			}
			return result;
		}
		public int Compare(Type lhs, Type rhs)
		{
			if (rhs.IsSubclassOf(lhs))
			{
				return -1;
			}
			else if (lhs.IsSubclassOf(rhs))
			{
				return +1;
			}
			else
			{
				var lAncs = Ancestors(lhs);
				var rAncs = Ancestors(rhs);
				int ix = 0;
				while (lAncs[ix] == rAncs[ix])
				{
					ix++;
				}
				return lAncs[ix].FullName.CompareTo(rAncs[ix].FullName);
			}
		}
