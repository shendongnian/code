    var partners = db.Context.PartnerEntity.AsQueryable();
    if (request.PartnerFilter != null && request.PartnerFilter.Any())
        partners = partners.Where(partner => request.PartnerFilter.Contains(partner.Name));
    
    var entity =
    ...
    join partner in partners on product.PartnerId equals partner.Id
    ...
    
