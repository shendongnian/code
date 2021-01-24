    public abstract class SynchronousSpecificationBase : ISpecification
    {
      public virtual Task<bool> IsSatisfiedByAsync(object candidate)
      {
        return Task.FromResult(IsSatisfiedBy(candidate));
      }
      protected abstract bool IsSatisfiedBy(object candidate);
    }
