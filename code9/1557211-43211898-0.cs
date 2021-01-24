     public class GdataHealthTableModel : AuditedEntity
     {
       public GdataHealthTableModel()
        {
          PrevHealthAssessment = new HashSet<HealthPrevHealthAssessmentEnum>();
        }
    
       public ICollection<HealthPrevHealthAssessmentEnum> PrevHealthAssessment { get; set; }
     }
