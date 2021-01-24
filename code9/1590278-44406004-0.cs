    public class Charge 
    { 
         public Guid ChargeMultiId { get; set; }
         public string ChargeMultiNoteslist { get; set; }
         public int ChargeMultiCode { get; set; }
         public string ChargeMultiCodeName { get; set; }
         public Guid ChargeMultiProcedureID { get; set; }
         public List<int> Diagnosis { get; set; }
    }
