	public interface IObjectWithState
	{
		ObjectState ObjectState { get; set; }
	}
	public enum ObjectState
	{
		Unchanged,
		Added,
		Modified
		Deleted
	}
