    class CompositeBindingList<T> : IList<T>, IBindingList, ICancelAddNew
    {
        private const string _kstrIndexOutOfRange = "index must be non-negative and less than Count";
        private readonly List<BindingList<T>> _sources = new List<BindingList<T>>();
        #region CompositeBindingList<T>-specific members
        public void AddBindingList(BindingList<T> list)
        {
            list.AddingNew += _OnAddingNew;
            list.ListChanged += _OnListChanged;
            _sources.Add(list);
            ListChanged?.Invoke(this, new ListChangedEventArgs(ListChangedType.Reset, 0));
        }
        public void RemoveBindingList(int index)
        {
            _sources.RemoveAt(index);
            ListChanged?.Invoke(this, new ListChangedEventArgs(ListChangedType.Reset, 0));
        }
        public int BindingListCount
        {
            get { return _sources.Count; }
        }
        #endregion
        #region BindingList-mirroring members
        public event AddingNewEventHandler AddingNew;
        public T AddNew()
        {
            if (_sources.Count == 0)
            {
                _sources.Add(new BindingList<T>());
            }
            return _sources[_sources.Count - 1].AddNew();
        }
        #endregion 
        #region IList<T> members
        public T this[int index]
        {
            get { return _sources[_GetSourceIndexOrThrow(ref index)][index]; }
            set { _sources[_GetSourceIndexOrThrow(ref index)][index] = value; }
        }
        public int Count => _sources.Sum(s => s.Count);
        public bool IsReadOnly => _sources.Cast<ICollection<T>>().All(s => s.IsReadOnly);
        public void Add(T item)
        {
            if (_sources.Count == 0)
            {
                _sources.Add(new BindingList<T>());
            }
            _sources[_sources.Count - 1].Add(item);
        }
        public void Clear() => _sources.Clear();
        public bool Contains(T item) => _sources.Any(s => s.Contains(item));
        public void CopyTo(T[] array, int arrayIndex)
        {
            foreach (BindingList<T> source in _sources)
            {
                source.CopyTo(array, arrayIndex);
                arrayIndex += source.Count;
            }
        }
        public IEnumerator<T> GetEnumerator() => _sources.SelectMany(s => s).GetEnumerator();
        public int IndexOf(T item)
        {
            var (source, index, baseIndex) = _GetIndexOf(item);
            return index >= 0 ? baseIndex + index : -1;
        }
        private (BindingList<T> source, int index, int baseIndex) _GetIndexOf(T item)
        {
            int baseIndex = 0;
            foreach (BindingList<T> source in _sources)
            {
                int index = source.IndexOf(item);
                if (index >= 0)
                {
                    return (source, index, baseIndex);
                }
                baseIndex += source.Count;
            }
            return (null, -1, -1);
        }
        public void Insert(int index, T item)
        {
            int sourceIndex = _GetSourceIndex(ref index);
            if (sourceIndex == -1)
            {
                if (index != 0)
                {
                    throw new IndexOutOfRangeException(_kstrIndexOutOfRange);
                }
                sourceIndex = _sources.Count - 1;
                index = _sources[sourceIndex].Count;
            }
            _sources[sourceIndex].Insert(index, item);
        }
        public bool Remove(T item)
        {
            var (source, index, baseIndex) = _GetIndexOf(item);
            if (index < 0)
            {
                return false;
            }
            else
            {
                source.RemoveAt(baseIndex + index);
                return true;
            }
        }
        public void RemoveAt(int index) => _sources[_GetSourceIndex(ref index)].RemoveAt(index);
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        #endregion
        #region ICollection members
        object ICollection.SyncRoot => throw new NotSupportedException();
        bool ICollection.IsSynchronized => false;
        void ICollection.CopyTo(Array array, int index)
        {
            CopyTo((T[])array, index);
        }
        #endregion 
        #region IList members
        bool IList.IsFixedSize => _sources.Cast<IList>().All(s => s.IsFixedSize);
        object IList.this[int index]
        {
            get => this[index];
            set => this[index] = (T)value;
        }
        int IList.Add(object value)
        {
            if (value is T)
            {
                Add((T)value);
                return Count - 1;
            }
            else
            {
                return -1;
            }
        }
        bool IList.Contains(object value)
        {
            return Contains((T)value);
        }
        int IList.IndexOf(object value)
        {
            return value is T ? IndexOf((T)value) : -1;
        }
        void IList.Insert(int index, object value)
        {
            Insert(index, (T)value);
        }
        void IList.Remove(object value)
        {
            if (value is T)
            {
                Remove((T)value);
            }
        }
        #endregion
        #region IBindingList members
        public event ListChangedEventHandler ListChanged;
        bool IBindingList.AllowNew => _sources.All(s => s.AllowNew);
        bool IBindingList.AllowEdit => _sources.All(s => s.AllowEdit);
        bool IBindingList.AllowRemove => _sources.All(s => s.AllowRemove);
        bool IBindingList.SupportsChangeNotification => _sources.Cast<IBindingList>().All(s => s.SupportsChangeNotification);
        bool IBindingList.SupportsSearching => _sources.Cast<IBindingList>().All(s => s.SupportsSearching);
        bool IBindingList.SupportsSorting => false;
        bool IBindingList.IsSorted => false;
        PropertyDescriptor IBindingList.SortProperty => throw new NotSupportedException();
        ListSortDirection IBindingList.SortDirection => throw new NotSupportedException();
        object IBindingList.AddNew()
        {
            return AddNew();
        }
        void IBindingList.AddIndex(PropertyDescriptor property)
        {
            foreach (IBindingList list in _sources)
            {
                list.AddIndex(property);
            }
        }
        void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
        {
            throw new NotSupportedException();
        }
        int IBindingList.Find(PropertyDescriptor property, object key)
        {
            int baseIndex = 0;
            foreach (IBindingList list in _sources)
            {
                int index = list.Find(property, key);
                if (index >= 0)
                {
                    return baseIndex + index;
                }
                baseIndex += list.Count;
            }
            return -1;
        }
        void IBindingList.RemoveIndex(PropertyDescriptor property)
        {
            foreach (IBindingList list in _sources)
            {
                list.RemoveIndex(property);
            }
        }
        void IBindingList.RemoveSort()
        {
            throw new NotSupportedException();
        }
        #endregion
        #region ICancelAddNew
        public void CancelNew(int itemIndex)
        {
            _sources[_sources.Count - 1].CancelNew(itemIndex);
        }
        public void EndNew(int itemIndex)
        {
            _sources[_sources.Count - 1].EndNew(itemIndex);
        }
        #endregion
        #region Private implementation details
        private void _OnListChanged(object sender, ListChangedEventArgs e)
        {
            int baseIndex = 0, sourceIndex = -1;
            for (int i = 0; i < _sources.Count; i++)
            {
                if (_sources[i] == sender)
                {
                    sourceIndex = i;
                    break;
                }
                baseIndex += _sources[i].Count;
            }
            if (sourceIndex == -1)
            {
                throw new Exception("internal exception -- unknown sender of ListChanged event");
            }
            ListChangedEventArgs e2;
            switch (e.ListChangedType)
            {
                case ListChangedType.ItemAdded:
                case ListChangedType.ItemChanged:
                case ListChangedType.ItemDeleted:
                    e2 = new ListChangedEventArgs(e.ListChangedType, e.NewIndex + baseIndex);
                    break;
                case ListChangedType.ItemMoved:
                    if (e.PropertyDescriptor != null)
                    {
                        e2 = new ListChangedEventArgs(e.ListChangedType, e.NewIndex + baseIndex, e.PropertyDescriptor);
                    }
                    else
                    {
                        e2 = new ListChangedEventArgs(e.ListChangedType, e.NewIndex + baseIndex, e.OldIndex + baseIndex);
                    }
                    break;
                case ListChangedType.PropertyDescriptorAdded:
                case ListChangedType.PropertyDescriptorChanged:
                case ListChangedType.PropertyDescriptorDeleted:
                    e2 = new ListChangedEventArgs(e.ListChangedType, e.PropertyDescriptor);
                    break;
                case ListChangedType.Reset:
                    e2 = new ListChangedEventArgs(e.ListChangedType, e.NewIndex + baseIndex);
                    break;
                default:
                    throw new ArgumentException("invalid value for e.ListChangedType");
            }
            ListChanged?.Invoke(this, e2);
        }
        private void _OnAddingNew(object sender, AddingNewEventArgs e)
        {
            AddingNew?.Invoke(this, e);
        }
        private int _GetSourceIndexOrThrow(ref int index)
        {
            int sourceIndex = _GetSourceIndex(ref index);
            if (sourceIndex >= 0)
            {
                return sourceIndex;
            }
            throw new IndexOutOfRangeException(_kstrIndexOutOfRange);
        }
        private int _GetSourceIndex(ref int index)
        {
            int sourceIndex = 0;
            while (sourceIndex < _sources.Count && index > _sources[sourceIndex].Count)
            {
                index -= _sources[sourceIndex].Count;
                sourceIndex++;
            }
            if (sourceIndex < _sources.Count)
            {
                return sourceIndex;
            }
            return -1;
        }
        #endregion
    }
