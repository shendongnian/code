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
        private AuthorizedDbContext _context;
        AuthorizedDbContext IValidatorByStateReader.Context => this._context;
        AuthorizedDbContext IValidatorByStateWriter.Context { set => this._context = value; }
    } 
