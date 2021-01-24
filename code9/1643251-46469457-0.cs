    var query = _content.RoutingRules.Where(r => r.BrandId == filter.BrandId);
    if (filter.OriginZoneId != null) {
        query = query.Where(r => r.OriginZoneId == filter.OriginZoneId);
    }
    if (filter.EshopServiceType != null) {
        query = query.Where(r => r.EshopServiceType == filter.EshopServiceType);
    }
    // etc...
    var result = query.ToArray();
