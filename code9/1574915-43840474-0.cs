    [XmlRoot("MedicalClearanceFormRoot")]
    public class MedicalClearanceViewModel
    {
        public MedicalClearanceFormElement MedicalClearanceForm { get; set; }
    }
    [XmlElement]
    public class MedicalClearanceFormElement
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
