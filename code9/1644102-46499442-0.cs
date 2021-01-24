    public class EntityPatientDiagnosis
    {
        //Diagnosis Id is automatically assigned   
        public int DiagnosisId { get; set; }
        public int PatientId { get; set; }
        public string Symptoms { get; set; }
        public string DiagnosisProvided { get; set;}
        public string AdministeredBy { get; set; }
        public DateTime DateofDiagnosis { get; set; }
        public string FollowUpRequired { get; set; }
        public DateTime DateOfFollowUp { get; set; }
    }
    public class EntityBilling
    {
        //BillId -> Primary Key ->set automatically
        public int BillId { get; set; }
        //DiagnosisId -> Foreign Key  unique
        public int DiagnosisId { get; set; }
  
        public int BillAmount { get; set; }
        public string CardNumber { get; set; }
        public string ModeOfPayment { get; set; }
    }
