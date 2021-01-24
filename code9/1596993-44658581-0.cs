    var info =  from a in tblItems
                group a by new
                {
                    a.ExpiryDate.Year,
                    a.ExpiryDate.Month
                } into bca
                select new ConsolidatedData()
                {
                    MonthField = bca.Key.ExpiryDate.Month,
                    YearField = bca.Key.ExpiryDate.Year,
                    CountField = bca.Count(),
                };
