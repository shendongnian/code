	public class Coordinate { 
		public Coordinate(int p, int q) {
			x = p;
			y = q;
		}
		
		private readonly int x; 
		private readonly int y;
	   
		public int X { get { return x; } }
		public int Y { get { return y; } }
		
		public override int GetHashCode() {
			unchecked // Overflow is fine, just wrap
			{
				int hash = (int) 2166136261;
				// Suitable nullity checks etc, of course :)
				hash = (hash * 16777619) ^ x.GetHashCode();
				hash = (hash * 16777619) ^ y.GetHashCode();
				return hash;
			}		
		}
		
		public override bool Equals(object obj) {
			if (obj == null)
				return false;
			
			var otherCoordinate = obj as Coordinate;
			if (otherCoordinate == null)
				return false;
				
			return
				this.X == otherCoordinate.X &&
				this.Y == otherCoordinate.Y;		
		}
	 }
