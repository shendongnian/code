    public class ObservableLinq<TIn, TOut> : IEnumerable<TOut>, INotifyCollectionChanged
    {
        private ObservableCollection<TIn> _Source;
        private Func<IEnumerable<TIn>, IEnumerable<TOut>> _Transformation;
        public ObservableLinq(ObservableCollection<TIn> source, Func<IEnumerable<TIn>, IEnumerable<TOut>> transformation)
        {
            _Source = source;
            _Transformation = transformation;
            _Source.CollectionChanged += Source_CollectionChanged;
        }
        public ObservableLinq(IEnumerable<TIn> source, Func<IEnumerable<TIn>, IEnumerable<TOut>> transformation)
            : this(source as ObservableCollection<TIn> ?? new ObservableCollection<TIn>(source), transformation)
        {
        }
        private void Source_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            RaiseCollectionChanged();
        }
        public IEnumerator<TOut> GetEnumerator()
        {
            return _Transformation(_Source).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        // could be a property as well, but this empathizes, that the source collection is not the primary functionality here
        public ObservableCollection<TIn> GetSourceCollection()
        {
            return _Source;
        }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        protected void RaiseCollectionChanged()
        {
            var handler = CollectionChanged;
            if (handler != null)
            {
                // always reset as it would be pretty complicated to track the actual changes across all the linq thingies
                handler(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
            }
        }
        /// <summary>
        /// Call when a filter relevant property changed on source collection entries
        /// </summary>
        public void CollectionChangedNeeded()
        {
            RaiseCollectionChanged();
        }
    }
