    var data = new Dictionary<string, object>() {
                                { "targetValue", calc.ListCalculationData.Select(i => (double)i.MRTargetValue).ToArray() },
                                { "ema12", calc.ListCalculationData.Select(i => (double)i.Ema12).ToArray() },
                                { "ema26", calc.ListCalculationData.Select(i => (double)i.Ema26).ToArray() },
                                { "ema", calc.ListCalculationData.Select(i => (double)i.Ema).ToArray() }
                                };
