    public string GetBasketTotalPrice(string basketLocation)
    {
        var basketTotalPrice = _driver.FindElements(CommonPageElements.BasketTotalPrice);
        return basketTotalPrice[GetElementIndexForBasketLocation(basketLocation)]
            .Text.Replace("£", "");
    }
    private int GetElementIndexForBasketLocation(string basketLocation)
    {
        if (basketLocation == null) throw new ArgumentNullException(nameof(basketLocation));
        return basketLocation.Equals("top", StringComparison.OrdinalIgnoreCase) ? 0 : 1;
    }
