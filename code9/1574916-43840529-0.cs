     public class MedicalClearanceForm
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
    [XmlRoot("MedicalClearanceFormRoot")]
    public class MedicalClearanceFormRoot
    {
        [XmlElement("MedicalClearanceForm")]
        public MedicalClearanceForm MedicalClearanceForm { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            string myXMLStringFromDB = @"<MedicalClearanceFormRoot><MedicalClearanceForm PassengerName = 'AAAAAAAAAAAAA' Age = '11' PhoneNo = 'TTTTTTTTTTT' Email = 'ZZZZZZZZZZZZZZZZZZZ' BookingRefNo = '11111111111111111111' /></MedicalClearanceFormRoot >";
            XmlSerializer serializer = new XmlSerializer(typeof(MedicalClearanceFormRoot));
            using (TextReader reader = new StringReader(myXMLStringFromDB))
            {
                MedicalClearanceFormRoot objModel = (MedicalClearanceFormRoot)serializer.Deserialize(reader);
            }
        }
    }
