    public class ProjectModel : IValidatableObject {
    
        public bool IsEditUsecase { get; set; }
    
        [Required(ErrorMessage = "*")] // required for every usecase
        public int Id { get; set; }
    
        // no [Required] and [StringLength] attributes 
        // because only required in some of the usecases
        public string Program { get; set; }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
             // validation that occurs only in Edit usecase
             if (IsEditUsecase) {
                 
                 // Validate "Program" property
                 if (string.IsNullOrWhiteSpace(Program) {
                     yield return new ValidationResult(
                            "Program is required",
                            new[] { "Program" }
                     );
                 } 
                 else if (Program.Length > 250) {
                     yield return new ValidationResult(
                         "Project name should not be more than 250 characters.",
                         new[] { "Program" }
                     );
                 }
    
                 // validate other properties for Edit usecase ...
             }
    
             // validate other usecases ...
         }
    }
