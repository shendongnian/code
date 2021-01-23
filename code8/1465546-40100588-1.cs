	public interface ILiving
	{
		float Health { get; }
	}
	public class Character : ILiving
	{
		// implement health as a normal variable
		public float Health { get; protected set; }
	}
	public class OldMan : ILiving
	{
		// implement health based on time until death at 2020
		public float Health { get { return (2020-DateTime.Now.Year)/20; } }
	}
