    public class OrganizationOptionsRepository : BaseEFRepository, IOrganizationOptionsRepository
        {
            private readonly IContextFactory ContextFactory;
    
            public OrganizationOptionsRepository(IContextFactory contextFactory)
            {
                ContextFactory = contextFactory;
            }
    
            public Result<IList<Country>> GetAllCountries()
            {
                using (var context = ContextFactory.CreateNew())
                {
                    IQueryable<Country> query = context.Countries.OrderBy(x => x.NiceName);
                    IList<Country> resultList = query.FromCache().ToList();
                    return Result.Ok(resultList);
                }
            }
        }
