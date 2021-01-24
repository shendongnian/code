    public class CenterConfiguration : IValidatableObject {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool? IsWaitingList { get; set; }
        public int? WaitingListEncounterOrOtherEncounter { get; set; }
    
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext) {
             if (IsWaitingList && !WaitingListEncounterOrOtherEncounter.HasValue) {
                 yield return new ValidationResult(
                     "Please enter waiting list encounter or other encounter",
                     new[] { "WaitingListEncounterOrOtherEncounter" }
                 );
             }
        }
    }
