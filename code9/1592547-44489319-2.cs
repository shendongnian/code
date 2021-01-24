	class Vector2D {
		public int X { get; private set; }
		public int Y { get; private set; }
		public Vector2D(int x, int y) {
			X = x;
			Y = y;
		}
		public Vector2D Clone(Vector2D vector) {
			return new Vector2D(vector.X, vector.Y);
		}
	}
