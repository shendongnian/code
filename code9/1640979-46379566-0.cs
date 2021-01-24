    	public class DupKey {
		public string Name { get; set; }
		public int Index { get; set; }
		public override string ToString() {
			return Name;
		}
		public override bool Equals(object obj) {
			if(!(obj is DupKey)) return false;
			return Index == ((DupKey)obj).Index;
		}
		public override int GetHashCode() {
			return Index.GetHashCode();
		}
	}
