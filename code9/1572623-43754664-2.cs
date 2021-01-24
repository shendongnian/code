        var currencyTables = CultureInfo.GetCultures(CultureTypes.SpecificCultures)
            .Select(s => new RegionInfo(s.LCID))
            .Select(r => new
            {
                Iso = r.ISOCurrencySymbol,
                Name = r.CurrencyEnglishName
            }).GroupBy(s => s.Iso)
            .OrderBy(r =>r.Key)
            .Select(a => new CurrencyTable{ Iso = a.Key, Name = a.FirstOrDefault().Name });
