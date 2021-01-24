    var filterMaterialConditionMap = AllPrices.GroupBy(ap => ap.Filter)
                                              .ToDictionary(apfg => apfg.Key, apfg => apfg.GroupBy(ap => ap.Material)
                                                                                          .ToDictionary(apfmg => apfmg.Key, apfmg => apfmg.ToLookup(ap => ap.ConditionClass)));
    PriceDto Price = null;
    if (filterMaterialConditionMap.TryGetValue(FilterId.ConsecutiveFilter.Trim(), out var matDict))
        if (matDict.TryGetValue(CodeMaterial, out var condDict))
            Price = condDict[accessSequenceItem.PriceCondition].FirstOrDefault();
