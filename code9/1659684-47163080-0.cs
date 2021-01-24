    public class DataValidator : AbstractValidator<Data> {
    
      public DataValidator() {
        // 'x' in this case is the instance of the 'Data' class being validated
        //
        RuleFor(x => x).Must(HaveMultiplierRelationship);
      }
    
      private bool HaveMultiplierRelationship(Data d)
      {
        return (d.PropertyA % d.PropertyB) == 0;
      }
    }
