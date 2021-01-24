	[Serializable]
	[DataContract]
	public class Usage
	{  
	   	private string _user;  
	   	private string _trackingUnit;  
	
		[DataMember]
		public string User {get {return _user;} set {_user = value;}}  
		[DataMember]
		public string TrackingUnit { get{return _trackingUnit;} set { _trackingUnit = value;}}
	}
