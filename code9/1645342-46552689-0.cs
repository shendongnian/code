	public static SomeContainer orientation(EntityStateRepository esr, ref double  heading, ref double pitch, ref double roll)
	{
		TaitBryan topoEuler = topoToGeoc.eulerTrans(esr.worldOrienation);
		var container = new SomeContainer();
		
		container.heading = MathHelper.RadiansToDegrees(topoEuler.psi);
		container.pitch = MathHelper.RadiansToDegrees(topoEuler.theta);
		container.roll = MathHelper.RadiansToDegrees(topoEuler.phi);
		
		return container;
	}
	public sealed class SomeContainer {
		public decimal heading {get;set;}
		public decimal pitch {get;set;}
		public decimal roll {get;set;}
	}
