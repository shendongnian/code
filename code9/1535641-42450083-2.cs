    decimal? CalculateShippingTotal(int itemCount, ShippingCharge charge) {
        decimal? total = null;
        if (charge != null) {
            var basePrice = charge.basePrice;
            var baseCount = charge.baseCount;
            if (itemCount > baseCount) {
                var qtyDifference = itemCount - baseCount;
                var additionalCost = qtyDifference * charge.unitPrice;
                total = basePrice + additionalCost;
            } else {
                total = itemCount * basePrice;
            }
        }
        return total;
    }
