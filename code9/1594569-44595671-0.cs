    public interface IMyObject {
		int Value { get; set; }
		bool Equals(object obj);
		int GetHashCode();
		IMyObject Clone();
	}
