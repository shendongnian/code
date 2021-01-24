    public class ConvertingCollection<TIn, TOut> : BaseConvertingCollection<TIn, TOut, ICollection<TIn>>
    {
        readonly Func<TOut, TIn> toInner;
        public ConvertingCollection(Func<ICollection<TIn>> getCollection, Func<TIn, TOut> toOuter, Func<TOut, TIn> toInner)
            : base(getCollection, toOuter)
        {
            if (toInner == null)
                throw new ArgumentNullException();
            this.toInner = toInner;
        }
        protected TIn ToInner(TOut outer) { return toInner(outer); }
        public override void Add(TOut item)
        {
            Collection.Add(ToInner(item));
        }
        public override void Clear()
        {
            Collection.Clear();
        }
        public override bool IsReadOnly { get { return Collection.IsReadOnly; } }
        public override bool Remove(TOut item)
        {
            return Collection.Remove(ToInner(item));
        }
        public override bool Contains(TOut item)
        {
            return Collection.Contains(ToInner(item));
        }
    }
    public abstract class BaseConvertingCollection<TIn, TOut, TCollection> : ICollection<TOut>
    where TCollection : ICollection<TIn>
    {
        readonly Func<TCollection> getCollection;
        readonly Func<TIn, TOut> toOuter;
        public BaseConvertingCollection(Func<TCollection> getCollection, Func<TIn, TOut> toOuter)
        {
            if (getCollection == null || toOuter == null)
                throw new ArgumentNullException();
            this.getCollection = getCollection;
            this.toOuter = toOuter;
        }
        protected TCollection Collection { get { return getCollection(); } }
        protected TOut ToOuter(TIn inner) { return toOuter(inner); }
        #region ICollection<TOut> Members
        public abstract void Add(TOut item);
        public abstract void Clear();
        public virtual bool Contains(TOut item)
        {
            var comparer = EqualityComparer<TOut>.Default;
            foreach (var member in Collection)
                if (comparer.Equals(item, ToOuter(member)))
                    return true;
            return false;
        }
        public void CopyTo(TOut[] array, int arrayIndex)
        {
            foreach (var item in this)
                array[arrayIndex++] = item;
        }
        public int Count { get { return Collection.Count; } }
        public abstract bool IsReadOnly { get; }
        public abstract bool Remove(TOut item);
        #endregion
        #region IEnumerable<TOut> Members
        public IEnumerator<TOut> GetEnumerator()
        {
            foreach (var item in Collection)
                yield return ToOuter(item);
        }
        #endregion
        #region IEnumerable Members
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
    }
