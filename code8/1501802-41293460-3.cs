	IAutomobile<JeepFeatures> auto = Autofactory.GetAuto<JeepFeatures>(param);
	auto.Rename(new JeepFeatures());
	IAutomobile auto_plain = auto;
	public interface IAutomobile { }
	
	public interface IAutomobile<P> : IAutomobile
	{
		void Rename(P parameters);
	}
	
	public abstract class Automobile<P> : IAutomobile<P>
	{
		public abstract void Rename(P parameters);
	}
	
	public class Jeep : Automobile<JeepFeatures>
	{
		public override void Rename(JeepFeatures parameters)
		{
		}
	}
