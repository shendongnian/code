	//...
    var bothGender = false;
    if (queryString.Get("gender") != null)
    {
        isMale = bool.Parse(queryString.Get("gender"));
    }
    else
	{
		bothGender = true;
	}
    
    if (priceArray.Count() == 2 && int.TryParse(priceArray[0], out minPrice) && int.TryParse(priceArray[1], out maxPrice))
    {
        selectedItems.AddRange(productTypes
            .Where(x => x.HasValue("price") &&
            x.GetPropertyValue<int>("price") > minPrice &&
            x.GetPropertyValue<int>("price") < maxPrice &&
            x.HasValue("gender") &&
            (bothGender || x.GetPropertyValue<bool>("gender") == isMale)) // <-- changes here
            .Skip((page - 1) * pageSize).Take(pageSize));
    //...
