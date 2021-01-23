	public class ListCycle<T> : IList<T>
	{
		int curIndex = -1;
		List<T> list;
		int nMax;
		public ListCycle(int n)
		{
			list = new List<T>(n);
			nMax = n;
		}
		/// <summary>returns the current index we are in the list</summary>
		public int CurIndex { get { return curIndex; } }
		public int IndexOf(T item) { return list.IndexOf(item); }
		public bool Contains(T item) { return list.Contains(item); }
		public int Count { get { return list.Count; } }
		public bool IsReadOnly { get { return false; } }
		public IEnumerator<T> GetEnumerator() { return list.GetEnumerator(); }
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return list.GetEnumerator(); }
		public T this[int index]
		{
			get { return list[index]; }
			set { list[index] = value; }
		}
		public void Add(T item)
		{
			curIndex++; if (curIndex >= nMax) curIndex = 0;
			if (curIndex < list.Count)
				list[curIndex] = item;
			else
				list.Add(item);
		}
		public void Clear()
		{
			list.Clear();
			curIndex = -1;
		}
		//other mehods/properties for IList ...
		public void Insert(int index, T item) { throw new NotImplementedException(); }
		public bool Remove(T item) { throw new NotImplementedException(); }
		public void RemoveAt(int index) { throw new NotImplementedException(); }
		public void CopyTo(T[] array, int arrayIndex) { throw new NotImplementedException(); }
	}
