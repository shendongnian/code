	public class TransportTypeViewMode : ViewModelBase
	{
		public TransportTypeViewMode()
		{
			TransportTypes= new List<TransportTypeEnum>();
			TransportTypes.add(TransportTypeEnum.Car);
			TransportTypes.add(TransportTypeEnum.Bus);
			TransportTypes.add(TransportTypeEnum.Plane);
		}      
        Public List<TransportTypeEnum> TransportTypes{get;set;}}
	}
