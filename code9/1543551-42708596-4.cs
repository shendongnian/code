        public List<CountryCurrencyPair> GetCountryList()
        {
            return CultureInfo.GetCultures(CultureTypes.SpecificCultures)
                .Select(c => new RegionInfo(c.LCID)).Distinct()
                .Select(r => new CountryCurrencyPair()
                {
                    Country = r.EnglishName,
                    Currency = r.CurrencyEnglishName
                }).ToList();
        }
