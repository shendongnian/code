	public class FloatIntDictionary
	{
		/// <summary>
		/// Stores as a Dictionary<int,int>(); And converts float on access.
		/// </summary>
		/// <param name="decPlaces"></param>
		public FloatIntDictionary(int decPlaces)
		{
			multiplier = (float)Math.Pow(10, decPlaces);
			dic = new Dictionary<int, int>();
		}
		readonly float multiplier;
		//FloatEqualityComparer _fec = new FloatEqualityComparer();
		readonly Dictionary<int, int> dic;
		int GetInt(float f)
		{
			return (int)(f * multiplier);
		}
		public float GetFloat(int i)
		{
			return i * multiplier;
		}
		public bool ContainsKey(float f)
		{
			int i = GetInt(f);
			return dic.ContainsKey(i);
		}
		public bool TryGetValue(float f, out int iVal)
		{
			int i = GetInt(f);
			return dic.TryGetValue(i, out iVal);
		}
		public int this[float fKey]
		{
			get
			{
				int iKey = GetInt(fKey);
				return dic[iKey];
			}
			set
			{
				int iKey = GetInt(fKey);
				dic[iKey] = value;
			}
		}
	}
