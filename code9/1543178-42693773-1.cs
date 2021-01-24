	public class Xi : X
	{
		public int I { get; }
		public int[] Other { get; }
		public Xi(int i) { I = i; }
		public Xi(int[] i) { Other = i; }
		public static implicit operator Xi(int i) { return new Xi(i); }
	}
