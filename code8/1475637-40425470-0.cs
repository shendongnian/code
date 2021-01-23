      public class EnrolmentEntity
    {
        public DateTime? ProgressDate { get; set; }
        public DateTime? FES_Start_Date { get; set; }
        public DateTime? AimStartDate { get; set; }
    }
//
     public class Enrolments
     {    
        [XmlElement("PROGRESS_STATUS")]
        public string ProgressStatus { get; set; }
        [XmlElement("PROGRESS_DATE")]
        public string ProgressDate { get; set; }
        [XmlElement("FES_START_DATE")]
        public string FES_Start_Date  { get; set; }
        [XmlElement("AIM_START")]
        public string AimStartDate { get; set; } 
 
     }
