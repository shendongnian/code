    public class ValidationResult
    {
         public ValidationResult()
         {
              Errors = new List<string>();
         }
    
        public bool IsValid{ get; set; }
        public List<string> Errors { get; set; }
    }
