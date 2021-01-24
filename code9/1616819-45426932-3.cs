    [HttpPost]
    public ActionResult Index(FormCollection form)
    {
        IList<ProductViewModel> updateItems = new List<ProductViewModel>();
    
        // form key formats
        // q_casecost = {q_guid}_q_casecost
        // q_sellprice = {q_guid}_q_sellprice
    
        //load your view model from database (note mine is just static)
    
        foreach(var item in viewModel.items)
        {
            var caseCostStr = form.Get(string.Format("{0}_q_casecost", item.q_guid)) ?? "";
            var sellPriceStr = form.Get(string.Format("{0}_q_sellprice", item.q_guid)) ?? "";
    
            decimal caseCost = decimal.Zero,
                    sellPrice = decimal.Zero;
    
            bool hasChanges = false;
    
            if (decimal.TryParse(caseCostStr, out caseCost) && caseCost != item.q_casecost)
            {
                item.q_casecost = caseCost;
                hasChanges = true;
            }
    
            if(decimal.TryParse(sellPriceStr, out sellPrice) && sellPrice != item.q_sellprice)
            {
                item.q_sellprice = sellPrice;
                hasChanges = true;
            }
    
            if (hasChanges)
                updateItems.Add(item);
        }
        //now updateItems contains only the items that have changes.
    
        return View();
    }
