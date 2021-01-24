    public virtual async Task<IQueryable<TDto>> Get(ODataQueryOptions<TDto> query)      
    {
        try
        {
            var expands = query.GetExpandedPropertyNames();
            
            //Assume the collection has the data from db
            var test = Collection.ToList();
            var entities = expands.ToList();
            
            // you can either use .Select to project using LINQ
            var dtos = await entities.Select(Mapper.Map<TDto>).AsTask();
            // or you can use Mapper.Map to a list of entities.
            dtos = await Mapper.Map<List<TDto>>(entities).AsTask();
            
            return dtos;
        }
        catch(Exception ex)
        {
            // side note, don't throw ex, you'll lose the stack trace
            throw;
        }
    }
