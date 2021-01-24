    public class YourModel : IValidatableObject
    {
        public string ProjNr { get; set; }
        public string SerialNr { get; set; }
        public string UserNr { get; set; }
        public string ClientNr { get; set; }
        public string ModelCode => $"{ProjNr}{SerialNr}{UserNr}{ClientNr}";
        // ...
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (/*check if ProjNr or other fields not valid*/)
              yield return new ValidationResult(
                      "ModelCode doesn't meet the requirements",
                      new [] {"ModelCode"}); // return only ModelCode member
        }
    }
