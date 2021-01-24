    public interface IValidatorByStateReadOnly 
    {
        AuthorizedDbContext Context { get; }
    }  
    internal interface IValidatorByState : IValidatorByStateReadOnly
    {
        new AuthorizedDbContext Context { get; set; }
    }
    public class ValidatorByState<TEntity> : IValidatorByState
    {
        private AuthorizedDbContext _context;
    
        public AuthorizedDbContext Context => _context;
    
        AuthorizedDbContext IValidatorByState.Context 
        {
            get => _context;
            set => _context = value; 
        }
    }
