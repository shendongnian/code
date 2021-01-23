    public class WorkListEntity
    {
      public string Formid { get; set; }
      //change to an action (e.g. in lambda terms, this would be () => {} - no parameters and no outputs
      public Action AfterAuditVoid { get; set; }
    }
