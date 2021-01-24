    var basketSummary = _driver.FindElements(CommonPageElements.BasketSummaryContent);
    if (basketLocation.ToLower() == "top")
    {
        decimal basketSummaryPrice = decimal.Parse(basketSummary[0].FindElements(CommonPageElements.BasePriceValue)[0].Text, NumberStyles.Currency, _ci);
        return basketSummaryPrice;
    }
    else
    {
        decimal basketSummaryPrice = decimal.Parse(basketSummary[1].FindElements(CommonPageElements.BasePriceValue)[0].Text, NumberStyles.Currency, _ci);
        return basketSummaryPrice;
    }
