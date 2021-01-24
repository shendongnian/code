	public interface IObjectWithState
	{
		ObjectState ObjectState { get; set; }
	}
	[Flags]
	public enum ObjectState
	{
		Unchanged = 1,
		Added = 2,
		Deleted = 8,
		Modified = 4
	}
