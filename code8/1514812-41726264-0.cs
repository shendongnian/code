	[XmlRoot(nameof(Parameters))]
	public sealed class ParametersModel
	{
		public int UserProfileState { get; set; }
		[XmlElement("Parameter")]
		public List<ParameterModel> Parameters { get; set; }
	}
