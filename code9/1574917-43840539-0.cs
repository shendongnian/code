	[XmlRoot("MedicalClearanceFormRoot")]
	public class Wrapper
	{
		
		public MedicalClearanceViewModel MedicalClearanceForm { get; set;}
	}
	public class MedicalClearanceViewModel
	{
		[XmlAttribute("PassengerName")]
		public string PassengerName { get; set; }
		[XmlAttribute("Gender")]
		public string Gender { get; set; }
		[XmlAttribute("Age")]
		public string Age { get; set; }
		[XmlAttribute("PhoneNo")]
		public string PhoneNo { get; set; }
		[XmlAttribute("Email")]
		public string Email { get; set; }
		[XmlAttribute("BookingRefNo")]
		public string BookingRefNo { get; set; }
	}
			XmlSerializer serializer = new XmlSerializer(typeof(Wrapper));
			using (TextReader reader = new StringReader(myXMLStringFromDB))
			{
				Wrapper objModel = (Wrapper)serializer.Deserialize(reader);
			}
Option 2: Change your XML to look like this:
<MedicalClearanceFormRoot PassengerName="AAAAAAAAAAAAA" Age="11" PhoneNo="TTTTTTTTTTT" Email="ZZZZZZZZZZZZZZZZZZZ" BookingRefNo="11111111111111111111" >  
</MedicalClearanceFormRoot>
