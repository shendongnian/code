    abstract class ImmutableList<T> : IEnumerable<T>
    {
        public static readonly ImmutableList<T> Empty = new EmptyList();
        public abstract IEnumerator<T> GetEnumerator();
        public abstract ImmutableList<T> AddLast(T t);
        public abstract ImmutableList<T> InsertFirst(T t);
        public ImmutableList<T> Join(ImmutableList<T> tail)
        {
            return new List(this, tail);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        class EmptyList : ImmutableList<T>
        {
            public override ImmutableList<T> AddLast(T t)
            {
                return new LeafList(t);
            }
            public override IEnumerator<T> GetEnumerator()
            {
                yield break;
            }
            public override ImmutableList<T> InsertFirst(T t)
            {
                return AddLast(t);
            }
        }
        abstract class NonEmptyList : ImmutableList<T>
        {
            public override ImmutableList<T> AddLast(T t)
            {
                return new List(this, new LeafList(t));
            }
            public override ImmutableList<T> InsertFirst(T t)
            {
                return new List(new LeafList(t), this);
            }
        }
        class LeafList : NonEmptyList
        {
            private readonly T _value;
            public LeafList(T t)
            {
                _value = t;
            }
            public override IEnumerator<T> GetEnumerator()
            {
                yield return _value;
            }
        }
        class List : NonEmptyList
        {
            private readonly ImmutableList<T> _head;
            private readonly ImmutableList<T> _tail;
            public List(ImmutableList<T> head, ImmutableList<T> tail)
            {
                _head = head;
                _tail = tail;
            }
            public override IEnumerator<T> GetEnumerator()
            {
                return _head.Concat(_tail).GetEnumerator();
            }
        }
    }
