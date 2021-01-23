	public class ImmutableStack<T>: IEnumerable<T>
	{
		private readonly T head;
		private readonly ImmutableStack<T> tail;
		public static readonly ImmutableStack<T> Empty = new ImmutableStack<T>(default(T), null);
		public int Count => this == Empty ? 0 : tail.Count + 1;
		private ImmutableStack(T head, ImmutableStack<T> tail)
		{
			this.head = head;
			this.tail = tail;
		}
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
		public ImmutableStack<T> Push(T value) => new ImmutableStack<T>(value, this);
		public IEnumerator<T> GetEnumerator()
		{
			var current = this;
			while (current != Empty)
			{
				yield return current.head;
				current = current.tail;
			}
		}
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
	struct Coordinates: IEquatable<Coordinates>
	{
		public int Row { get; }
		public int Column { get; }
		public Coordinates(int row, int column)
		{
			Row = row;
			Column = column;
		}
		public bool Equals(Coordinates other) => Column == other.Column && Row == other.Row;
		public override bool Equals(object obj)
		{
			if (obj is Coordinates)
			{
				return Equals((Coordinates)obj);
			}
			return false;
		}
		public override int GetHashCode() => unchecked(27947 ^ Row ^ Column);
		public IEnumerable<Coordinates> GetNeighbors(int rows, int columns)
		{
			var canIncreaseRow = Row < rows - 1;
			var canIncreaseColumn = Column < columns - 1;
			var canDecreaseRow = Row > 0;
			var canDecreaseColumn = Column > 0;
			var increasedRow = Row + 1;
			var decreasedRow = Row - 1;
			var increasedColumn = Column + 1;
			var decreasedColumn = Column - 1;
			if (canDecreaseRow)
			{
				if (canDecreaseColumn)
				{
					yield return new Coordinates(decreasedRow, decreasedColumn);
				}
				yield return new Coordinates(decreasedRow, Column);
				if (canIncreaseColumn)
				{
					yield return new Coordinates(decreasedRow, increasedColumn);
				}
			}
			if (canIncreaseRow)
			{
				if (canDecreaseColumn)
				{
					yield return new Coordinates(increasedRow, decreasedColumn);
				}
				yield return new Coordinates(increasedRow, Column);
				if (canIncreaseColumn)
				{
					yield return new Coordinates(increasedRow, increasedColumn);
				}
			}
			if (canDecreaseColumn)
			{
				yield return new Coordinates(Row, decreasedColumn);
			}
			if (canIncreaseColumn)
			{
				yield return new Coordinates(Row, increasedColumn);
			}
		}
	}
