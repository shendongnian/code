	class Vector2D {
		readonly int x_, y_;
		public int X { get { return x_; } }
		public int Y { get { return y_; } }
		public Vector2D(int x, int y) {
			x_ = x;
			y_ = y;
		}
		public Vector2D Clone(Vector2D vector) {
			return new Vector2D(vector.X, vector.Y);
		}
	}
