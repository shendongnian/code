	public interface IAutomobile
	{
		void Rename(string p1, int p2);
	}
	
	public interface IAutomobile<P1, P2> : IAutomobile
	{
		void Rename(P1 p1, P2 p2);
	}
	
	public abstract class Automobile<P1, P2> : IAutomobile<P1, P2>
	{
		// Lots of properties and methods...
	
		public abstract void Rename(P1 p1, P2 p2);
	}
	
	public class Jeep : Automobile<string, int>
	{
		public override void Rename(string p1, int p2)
		{
			// Uses p1 & p2 with the base class
		}
	}
