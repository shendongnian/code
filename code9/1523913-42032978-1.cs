    public class ValidationResult
    {
         public ValidationResult()
         {
              Errors = new List<string>();
         }
    
        public bool IsValid{ get { return (Errors.Count() == 0); } }
        public List<string> Errors { get; set; }
    }
