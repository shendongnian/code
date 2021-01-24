    [XmlRoot("ReconciliationRequest", Namespace = "http://schemas.capita.co.uk/pcse/crm")]
    public class ReconciliationRequest
    {
        [XmlElement("Patient")]    
        public List<Patient> PatientDetails;
    }
