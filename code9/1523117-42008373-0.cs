    var result = LowRiskFactorModel.GroupBy(m => m.RiskFactorName)
                                   .Select(g => new RiskFactorModel
                                     {
                                         RiskFactorName = g.Key,
                                         RiskFactorNameChild = g.SelectMany(m => m.RiskFactorNameChild).ToList()
                                     }).ToList();
