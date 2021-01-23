    public decimal? CalculateRate(int totalweight, IList<Rate> lookup) {
        decimal? result = null;
        var availableRates = lookup.OrderBy(r => r.weight);
        var rate = availableRates.FirstOrDefault(r => totalweight <= r.weight) ?? availableRates.LastOrDefault();
        if (rate != null) {
            if (rate.baseWeight != null) {
                var baseRate = rate.basePrice;
                var weighDiff = totalweight - rate.baseWeight.GetValueOrDefault();
                var weightDiffUnits = (int)Math.Ceiling((double)weighDiff / (double)rate.unitWeight.GetValueOrDefault());
                var pricePerDiff = rate.unitPrice.GetValueOrDefault();
                var weightDiffRate = weightDiffUnits * pricePerDiff;
                result = baseRate + weightDiffRate;
            } else {
                result = rate.basePrice;
            }
        }
        return result;
    }
