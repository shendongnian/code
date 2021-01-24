    public interface IValidatorByStateReader
    {
        AuthorizedDbContext Context { get; }
    }
    
    internal interface IValidatorByStateWriter
    {
        AuthorizedDbContext Context { set; }
    }
    
    public class ValidatorByState<TEntity> : IValidatorByStateReader, IValidatorByStateWriter
    {
        public AuthorizedDbContext Context { get; set; }
    } 
