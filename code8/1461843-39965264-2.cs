	[XmlRoot(ElementName="header")]
	public class Header {
		// I modified the types of these properties from string to Guid
		[XmlElement(ElementName="from_application_id")]
		public Guid From_application_id { get; set; }
		[XmlElement(ElementName="to_application_id")]
		public Guid To_application_id { get; set; }
	}
	[XmlRoot(ElementName="client")]
	public class Client {
		[XmlElement(ElementName="first_name")]
		public string First_name { get; set; }
		[XmlElement(ElementName="last_name")]
		public string Last_name { get; set; }
		[XmlAttribute(AttributeName="client_id")]
		public string Client_id { get; set; }
	}
	[XmlRoot(ElementName="patient_weight")]
	public class Patient_weight {
		// I changed weight from string to decimal
		[XmlElement(ElementName="weight")]
		public decimal Weight { get; set; }
		[XmlAttribute(AttributeName="patient_weight_uom")]
		public string Patient_weight_uom { get; set; }
	}
	[XmlRoot(ElementName="patient")]
	public class Patient {
		[XmlElement(ElementName="patient_name")]
		public string Patient_name { get; set; }
		[XmlElement(ElementName="patient_breed")]
		public string Patient_breed { get; set; }
		[XmlElement(ElementName="patient_birth_dt")]
		public string Patient_birth_dt { get; set; }
		[XmlElement(ElementName="patient_weight")]
		public Patient_weight Patient_weight { get; set; }
		[XmlAttribute(AttributeName="patient_id")]
		public string Patient_id { get; set; }
		[XmlAttribute(AttributeName="patient_species")]
		public string Patient_species { get; set; }
		[XmlAttribute(AttributeName="patient_gender")]
		public string Patient_gender { get; set; }
	}
	[XmlRoot(ElementName="doctor")]
	public class Doctor {
		[XmlElement(ElementName="first_name")]
		public string First_name { get; set; }
		[XmlElement(ElementName="last_name")]
		public string Last_name { get; set; }
	}
	[XmlRoot(ElementName="work_request")]
	public class Work_request {
		[XmlElement(ElementName="client")]
		public Client Client { get; set; }
		[XmlElement(ElementName="patient")]
		public Patient Patient { get; set; }
		[XmlElement(ElementName="doctor")]
		public Doctor Doctor { get; set; }
		// I simplied this into a list of strings.
		[XmlArray(ElementName="service_add")]
		[XmlArrayItem("service_cd")]
		public List<string> Service_add { get; set; }
		[XmlAttribute(AttributeName="requisition_number")]
		public string Requisition_number { get; set; }
	}
	[XmlRoot(ElementName="body")]
	// I renamed this to WorkRequestBody
	public class WorkRequestBody 
	{
		[XmlElement(ElementName="work_request")]
		public Work_request Work_request { get; set; }
	}
	[XmlRoot(ElementName="message")]
	// I made this generic to account for multiple types of messge.
	public class Message<T> where T : class, new()
	{
		[XmlElement(ElementName="header")]
		public Header Header { get; set; }
		[XmlElement(ElementName="body")]
		public T Body { get; set; }
		[XmlAttribute(AttributeName="message_id")]
		public string Message_id { get; set; }
		[XmlAttribute(AttributeName="message_dt")]
		public string Message_dt { get; set; }
		[XmlAttribute(AttributeName="message_type")]
		public string Message_type { get; set; }
		[XmlAttribute(AttributeName="message_sub_type")]
		public string Message_sub_type { get; set; }
		[XmlAttribute(AttributeName="message_dtd_version_number")]
		public string Message_dtd_version_number { get; set; }
	}
