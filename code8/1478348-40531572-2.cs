    if (search.ServiceId == 0)
    {
        return new Partner[] {};
    }
        
    if (search.BrandId == 0)
    {
        return new Partner[] {};
    }
        
    if (search.TrailerService != true)
    {
        return new Partner[] {};
    }
        
    return dbContext.Partners
        .Where(p => p.PartnerServiceBrands
                     .Select(psb => psb.Service.Id)
                     .Contains(search.ServiceId))
        .Where(p => p.PartnerServiceBrands
                     .Select(psb => psb.Brand.Id)
                     .Contains(search.BrandId))
        .Where(x => x.PartnerServiceBrands
                     .Any(y => y.TrailerService == true));
