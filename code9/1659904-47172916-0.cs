    private void ReadAll(Entities context)
        {
            var allPromotions =
            (from pro in context.PROMOS.AsNoTracking()
                join krig in context.KRIGS.AsNoTracking() on pro.PROM_ID equals
                krig.PROM_ID
                where pro.VALUE >= 0
                group new ItemList
                {
                    Id = krig.KRIG_ID,
                    Quantity = krig.KRIG_VALUE.HasValue ? krig.KRIG_VALUE.ToString() : "1",
                }
                by pro into proGrpup
                select new Promotion
                {
                    Id = proGrpup.Key.PROM_ID,
                    Description = proGrpup.Key.DESCRIPT,
                }
            ).ToList();
        }
