    var iqable = _crmDbContext.CRMPeoples
            .Where(p =>
                p.Name.ToLower().Contains(query) ||
                p.CRMEmails.Where(e => e.EmailAddress.ToLower().Contains(query)).Any() ||
                p.CRMPhones.Where(h => h.PhoneNumberNormalized.Contains(query)).Any())
            .Select(p => new CRMSearchResultDTO()
            {
                PersonName = p.Name,
                LocationName = p.CRMLocations.Name,
            });
