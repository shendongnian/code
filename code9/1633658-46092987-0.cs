    public interface IZone<out T> where T : Media.Medium
    {
        //important stuff here
    }
	public class Zone<T> : IZone<T> where T : Media.Medium
	{
		...
	}
	public abstract class Node
	{
		public IZone<Media.Medium> ParentZone;
    }
