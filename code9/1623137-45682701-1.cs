    public class AndSpecification : ISpecification 
    {
      ...
      public async Task<bool> IsSatisfiedByAsync(object o) 
      {
        return await leftCondition.IsSatisfiedByAsync(o) && await rightCondition.IsSatisfiedByAsync(o);
      }
    }
    public static class SpecificationExtensions
    {
      public static ISpecification And(ISpeicification @this, ISpecification other) =>
          new AndSpecification(@this, other);
    }
