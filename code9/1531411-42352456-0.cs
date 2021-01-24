	class SomeTypeBindingList : IBindingList, ICancelAddNew
	{
		public SomeTypeBindingList(SomeObject someObject)
		{
			_someObject = someObject;
			var observableCollection = _someObject.Items as ObservableCollection<SomeType>;
			if (observableCollection != null)
				observableCollection.CollectionChanged += ObservableCollectionOnCollectionChanged;
		}
		public IEnumerator GetEnumerator()
		{
			return new SomeTypeEnumerator(this);
		}
		public int Count => _someObject.Items.Count + (_newItem == null ? 0 : 1);
		public object SyncRoot { get; } = new object();
		public bool IsSynchronized { get; } = false;
		public bool Contains(object value)
		{
			return IndexOf(value) != -1;
		}
		public int IndexOf(object value)
		{
			if (ReferenceEquals(value, _newItem))
				return _someObject.Items.Count;
			return _someObject.Items.IndexOf((SomeType)value);
		}
		public void Remove(object value)
		{
			var someType = (SomeType)value;
			_someObject.RemoveItem(someType);
		}
		public void RemoveAt(int index)
		{
			var someType = _someObject.Items[index];
			_someObject.RemoveItem(someType);
		}
		public object this[int index]
		{
			get
			{
				if (index >= _someObject.Items.Count)
				{
					if(_newItem == null)
						throw new IndexOutOfRangeException();
					return _newItem;
				}
				return _someObject.Items[index];
			}
			set
			{
				throw new NotImplementedException();
			}
		}
		public object AddNew()
		{
			_newItem = new SomeType();
			ListChanged?.Invoke(this, new ListChangedEventArgs(ListChangedType.ItemAdded, _someObject.Items.Count));
			return _newItem;
		}
		public void CancelNew(int itemIndex)
		{
			_newItem = null;
			ListChanged?.Invoke(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, itemIndex));
		}
		public void EndNew(int itemIndex)
		{
			if (_newItem != null)
			{
				var someType = _newItem;
				_newItem = null;
				_someObject.AddItem(someType);
			}
		}
		private void ObservableCollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			if (e.Action == NotifyCollectionChangedAction.Remove)
				Enumerable.Range(e.OldStartingIndex, e.OldItems.Count).ForEach(i => ListChanged?.Invoke(this, new ListChangedEventArgs(ListChangedType.ItemDeleted, i)));
			else if(e.Action == NotifyCollectionChangedAction.Add)
				Enumerable.Range(e.NewStartingIndex, e.NewItems.Count).ForEach(i => ListChanged?.Invoke(this, new ListChangedEventArgs(ListChangedType.ItemAdded, i)));
		}
		private readonly SomeObject _someObject;
		private SomeType _newItem;
		class SomeTypeEnumerator : IEnumerator
		{
			public SomeTypeEnumerator(SomeObject someObject)
			{
				_someObject = someObject;
				Reset();
			}
			public void Dispose()
			{
                
			}
			public bool MoveNext()
			{
				_index++;
				return _someObject.Items.Count < _index;
			}
			public void Reset()
			{
				_index = -1;
			}
			public object Current => _someObject.Items[_index];
			object IEnumerator.Current
			{
				get { return Current; }
			}
			private readonly SomeObject _someObject;
			private int _index;
		}
	}
