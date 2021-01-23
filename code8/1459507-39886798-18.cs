    public class ImmutableStack<T> : IEnumerable<T>
    {
        private readonly T head;
        private readonly ImmutableStack<T> tail;
        public int Count { get; }
        public static readonly ImmutableStack<T> Empty = new ImmutableStack<T>();
        private ImmutableStack()
        {
            head = default(T);
            tail = null;
            Count = 0;
        }
        private ImmutableStack(T head, ImmutableStack<T> tail)
        {
            Debug.Assert(tail != null);
            this.head = head;
            this.tail = tail;
            Count = tail.Count + 1;
        }
        public ImmutableStack<T> Push(T item) => new ImmutableStack<T>(item, this);
        public T Peek()
        {
            if (this == Empty)
                throw new InvalidOperationException("Can not peek an empty stack.");
            return head;
        }
        public ImmutableStack<T> Pop()
        {
            if (this == Empty)
                throw new InvalidOperationException("Can not pop an empty stack.");
            return tail;
        }
        public IEnumerator<T> GetEnumerator()
        {
            var current = this;
            while (current != Empty)
            {
                yield return current.Peek();
                current = current.tail;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public override string ToString() => string.Join(" -> ", this);
    }
       
    public class Point: IEquatable<Point>
    {
        private readonly List<Point> connectedPoints;
        public int X { get; }
        public int Y { get; }
        public IEnumerable<Point> ConnectedPoints => connectedPoints.Select(p => p);
        public Point(int x, int y)
        {
            X = x;
            Y = y;
            connectedPoints = new List<Point>();
        }
        public void ConnectWith(Point p)
        {
            Debug.Assert(p != null);
            Debug.Assert(!Equals(p));
            if (!connectedPoints.Contains(p))
            {
                connectedPoints.Add(p);
                p.connectedPoints.Add(this);
            }
        }
        public bool Equals(Point p)
        {
            if (ReferenceEquals(p, null))
                return false;
            return X == p.X && Y == p.Y;
        }
        public override bool Equals(object obj) => this.Equals(obj as Point);
        public override int GetHashCode() => X ^ Y;
        public override string ToString() => $"[{X}, {Y}]";
    }
    public class Room
    {
        public IEnumerable<Point> Points { get; }
        public Room(IEnumerable<Point> points)
        {
            Points = points;
        }
    }
