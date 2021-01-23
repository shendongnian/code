    [Serializable]
    [XmlRoot("Parameters")]
    public class ParametersModel
    {
    	[XmlElement]
    	public int UserProfileState { get; set; }	
    	
    	[XmlElement("Parameter")]	
    	public List<ParameterModel> Parameters { get; set; }
    }
