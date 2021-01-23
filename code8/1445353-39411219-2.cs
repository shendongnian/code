	class SortedBiDcit<T1, T2> //this assumes T1 and T2 are different (and not int for indexer) and values are unique
	{
		Dictionary<T1, Tuple<T2, int>> dict1 = new Dictionary<T1, Tuple<T2, int>>();
		Dictionary<T2, T1> dict2 = new Dictionary<T2, T1>();
		
		List<T1> indices = new List<T1>();
        public int Count { get { return indices.Count; } }
		public T2 this[T1 arg]
		{
			get { return dict1[arg].Item1; }
		}
		
		public T1 this[T2 arg]
		{
			get { return dict2[arg]; }
		}
		
		public Tuple<T1, T2> this[int index]
		{
			get
			{
				T1 arg1 = indices[index];
				return new Tuple<T1, T2>(arg1, dict1[arg1].Item1);
			}
		}
		
		public void Add(T1 arg1, T2 arg2)
		{
			dict1[arg1] = new Tuple<T2, int>(arg2, indices.Count);
			dict2[arg2] = arg1;
			
			indices.Add(arg1);
		}
		
		public void Erase(T1 arg)
		{
			var arg2 = dict1[arg];
			dict1.Remove(arg);
			dict2.Remove(arg2.Item1);
			indices.RemoveAt(arg2.Item2);
		}
		
		public void Erase(T2 arg)
		{
			var arg2 = dict2[arg];
			var arg1 = dict1[arg2];
			
			dict1.Remove(arg2);
			dict2.Remove(arg1.Item1);
			indices.RemoveAt(arg1.Item2);
		}
	}
