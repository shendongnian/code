    public class Class1Data : IValidatableObject
    {
        public int Id { get; set; }
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
        public string Prop10 { get; set; }
        public Func<string> AcquiresParentProp { get; set; }
        // Validate Model
        private bool validated = false;
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
              if (!validated)
              {
                     if ((Prop1 != value1) || (Prop2 != value2))
                     {
                           // CALL EXTERNAL API
                         if(AcquiresParentProp != null)
                         {
                             var parentProp = AcquiresParentProp();
                             // use parentProp
                         }
                     }
                     validated = true;
              }     
            yield return ValidationResult.Success;
        }
    }
