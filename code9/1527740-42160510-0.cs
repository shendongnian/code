    data.RawMaterail.Where(c => c.Category.categoryType == 1)
                    .Join(data.Sizes, x => x.DiamondSize.diamondSizeId, 
                                      y => y.DiamondSize.diamondSizeId, 
                                      (x, y) => new { RM = x, Size = y })
                    .GroupJoin(data.PriceLevels.Where(c => c.priceLevelId == PriceLevelId), 
                               x => new { RID = (int?)x.RM.rMId , SID = (int?)x.Size.sizeId}, 
                               y => new { RID = (int?)y.rmId , SID = (int?)y.sizeId}, 
                               (y, x) => new { Category = y, PurityLevel = x })
                    .SelectMany(xy => xy.PurityLevel.DefaultIfEmpty(), 
                               (x, y) => new { Category = x.Category, PurityLevel = y })
                    .Select(item => new
                     {
                         Code = item.Category.RM.rMCode + " " + item.Category.Size.sizeName,
                         Name = item.Category.RM.rMName + " " + item.Category.Size.sizeName,
                         Date = item.PurityLevel.rowDate,
                         Id = (int)item.Category.RM.rMId,
                         RateId = (int?)item.PurityLevel.stonePriceLevelId ?? 0,
                         Price = (double?)item.PurityLevel.price ?? 0,
                         PriceLevelId = (int?)item.PurityLevel.priceLevelId ?? 0,
                         TypeId = (int)item.Category.Size.sizeId,
                         IsRateChanged = false
                     }).OrderBy(c => c.Date).ThenBy(n => n.TypeId).ToList();
