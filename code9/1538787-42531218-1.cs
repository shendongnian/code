    public IEnumerable<VendorDto> GetVendors(string sourceLanguage = null, string targetLanguage = null, string service = null)
            {
                var vendorsQuery = _context.Vendors
                    .Include(v => v.Translations.Select(t => t.SourceLanguage))
                    .Include(v => v.Translations.Select(t => t.TargetLanguage))
                    .Include(v => v.Translations.Select(t => t.Service))
                    .Include(v => v.Currency)
    				// consider adding a .ToList() right here based on how many records you have
    				
    				Expression<Func<Translation, bool>> sourceLanguagePredicate = z => z.SourceLanguage.Name == sourceLanguage;
    				Expression<Func<Translation, bool>> targetLanguagePredicate = z => z.TargetLanguage.Name == targetLanguage;
    				Expression<Func<Translation, bool>> servicePredicate = z => z.Service.Name == service;
    				
    				var hasSource = !string.IsNullOrWhiteSpace(sourceLanguage);
    				var hasTarget = !string.IsNullOrWhiteSpace(targetLanguage);
    				var hasService = !string.IsNullOrWhiteSpace(service);
    				if(hasSource)
    				{
    					vendorsQuery = vendorsQuery.Where(x => x.Translations.AsQueryable().Any(sourceLanguagePredicate));
    				}
    				
    				if(hasTarget)
    				{
    					vendorsQuery = vendorsQuery.Where(x => x.Translations.AsQueryable().Any(targetLanguagePredicate));
    				}
    				
    				if(hasService)
    				{
    					vendorsQuery = vendorsQuery.Where(x => x.Translations.AsQueryable().Any(servicePredicate));
    				}
    				
    				var vendors = vendorsQuery.ToList();
    				
    				foreach(var vendor in vendors)
    				{
    					if(hasSource)
    					{			
    						vendor.Translations = vendor.Translations.Where(sourceLanguagePredicate).ToList();
    					}
    					
    					if(hasTarget)
    					{			
    						vendor.Translations = vendor.Translations.Where(targetLanguagePredicate).ToList();
    					}
    				
    					if(hasService)
    					{			
    						vendor.Translations = vendor.Translations.Where(servicePredicate).ToList();
    					}
    				}
    				
    				return vendors.Select(Mapper.Map<Vendor, VendorDto>);
            }
