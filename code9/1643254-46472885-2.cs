    [HttpPost("filtered")]
    public IActionResult GetFilteredRoutingRules([FromBody] RoutingSearchFilterDto filter)
    {
        // Query to be build on the routing rules table.
        IQueryable<RoutingRules> query = _context.RoutingRules;
    
        // Populate the linked foreign key entities.
        query.Include(x => x.Hub).Include(y => y.DestinationZone).Include(z => z.OriginZone);
        
        // Build dynamic where statements.
        if (filter.BrandId != null)
            query = query.Where(r => r.BrandId == filter.BrandId);
    
        if (filter.OriginZoneId != null)            
            query = query.Where(r => r.OriginZoneId == filter.OriginZoneId);
    
        if (filter.DestinationZoneId != null)
            query = query.Where(r => r.DestinationZoneId == filter.DestinationZoneId);
    
        if (filter.IsRuleActive != null)
            query = query.Where(r => r.IsRuleActive == filter.IsRuleActive);
    
        if (filter.RuleRanking != null)
            query = query.Where(r => r.RuleRanking == filter.RuleRanking);
        
        // If you want to add paging:
        query = query.Skip(filter.PageSize * filter.PageNumber).Take(filter.PageSize);
        // Perform select on the table and map the results.
        var result = query.Select(r => new RoutingRulesDto
        {
            RoutingRuleId = r.RoutingRuleId,
            BrandId = r.BrandId,
            LastMileCarrierCode = r.LastMileCarrierCode,
            CashOnDelivery = r.CashOnDelivery,
            CreationTime = r.CreationTime,
            CurrencyCode = r.CurrencyCode,
            CurrencyDescription = Enum.Parse(typeof(Enumerations.CurrencyCode), r.CurrencyCode),
            DestinationZoneId = r.DestinationZoneId,
            EddFromDay = r.EddFromDay,
            EddToDay = r.EddToDay,
            ServiceType = r.ServiceType,
            ServiceTypeName = Enum.Parse(typeof(Enumerations.ServiceType), r.EshopServiceType),
            IsPickUpAvailable = r.IsPickUpAvailable,
            LastUpdateTime = r.LastUpdateTime,
            LastUpdateUser = r.LastUpdateUser,
            OriginZoneId = r.OriginZoneId,
            RuleRanking = r.RuleRanking,
            SignOnDelivery = r.SignOnDelivery,
            TermsOfDelivery = r.TermsOfDelivery,
            TermsOfDeliveryName = Enum.Parse(typeof(Enumerations.TermsOfDelivery), r.TermsOfDelivery),
            ValueOfGoods = r.ValueOfGoods,
            WeightLowerLimit = r.WeightLowerLimit,
            WeightUpperLimit = r.WeightUpperLimit,
            FirstMileCarrierCode = r.FirstMileCarrierCode,
            HubId = r.HubId,
            IsInsuranceAvailable = r.IsInsuranceAvailable,
            IsRuleActive = r.IsRuleActive,
            HubName = r.Hub.HubName,
            DestinationZoneName = r.DestinationZone.ZoneName,
            OriginZoneName = r.OriginZone.ZoneName,
        });
    
        // The SQL produced includes the joins and where clauses as well as only 
        // selecting the column names that are required in the flattened return object.
    
        return Ok(result);
    }
