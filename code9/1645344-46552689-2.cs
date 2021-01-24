	public static OrientationModel orientation(EntityStateRepository esr)
	{
		TaitBryan topoEuler = topoToGeoc.eulerTrans(esr.worldOrienation);
		var container = new OrientationModel();
		
		container.heading = MathHelper.RadiansToDegrees(topoEuler.psi);
		container.pitch = MathHelper.RadiansToDegrees(topoEuler.theta);
		container.roll = MathHelper.RadiansToDegrees(topoEuler.phi);
		
		return container;
	}
	public sealed class OrientationModel {
		public decimal heading {get;set;}
		public decimal pitch {get;set;}
		public decimal roll {get;set;}
	}
