    var baseQuery = db.PartnerServiceBrands.AsNoTracking();
    
    if(filterTrailer.hasValue){
    	baseQuery = baseQuery.Where(x=> x.TrailerService == filterTrailer.Value);
    }
    
    if(filterServiceId.hasValue){
    	baseQuery = baseQuery.Where(x=>x.ServiceId == filterServiceId);	
    }
    
    if(filterServiceId.hasValue){
    	baseQuery = baseQuery.Where(x=>x.BrandId == filterBrandId);	
    }
    
    var results = baseQuery.Select(x=>x.Partner)
    					   .ToList();
