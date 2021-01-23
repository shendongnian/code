	public class WckyObj
	{
		public string wackyId {get; set;}
		public string wackyType {get; set;}
		public string wackyCnfdc {get; set;}
		public List<WckyArray> wckyArr {get; set;}
	}
	public class WckyArray
	{
		public string fieldName {get; set;}
		public string fieldValue {get; set;}
		public string fieldConfidence {get; set;}
	}
