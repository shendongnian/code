	interface IEnumerable<T> {
		// just like we currently have
	}
	interface ICollection<T> : IEnumerable<T> {
		int Count { get; }
	}
	interface IIndexedCollection<T> : ICollection<T> {
		T this[int index] { get; }
	}
	interface IMutableCollection<T> : ICollection<T> {
		void Add(T item);
		bool Remove(T item);
		void Clear();
	}
	interface IArray<T> : IIndexedCollection<T> {
		T this[int index] { get; set; }
	}
	interface IList<T> : IArray<T>, IMutableCollection<T> {
		void Insert(int index, T item);
		void RemoveAt(int index);
	}
