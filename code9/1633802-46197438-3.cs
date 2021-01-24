    private static IEnumerable<BikeModel> ConvertToModel(IEnumerable<BikeTable> enumerable)
    {
        return enumerable.Select(ConvertToModel);
    }
    
    public async Task<IEnumerable<TenantEntity>> Find(string term)
    {    
        var lst = await _bikeRepository.GetAllAsync();
    
        return ConvertToModel(lst);
    }
