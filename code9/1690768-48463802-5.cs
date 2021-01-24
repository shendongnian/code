    public class BaseController<TEntity, TViewModel>
    {    
        public async Task<IEnumerable<TViewModel>> GetAll()
        {
            return await filterListsDbContext.Set<TEntity>()
                .AsNoTracking()
                .ProjectTo<TViewModel>()
                .ToArrayAsync();
        }
    }
    public class LanguageController : BaseController<Language, LanguageSeedDto>
    {
        (in some action)
        var data = await GetAll();
    }
