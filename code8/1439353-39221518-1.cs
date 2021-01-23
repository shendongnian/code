    public ActionResult EditLocation(string LocationId)
    {
	try
	{
		if (Session["Type"] == null)
			return RedirectToAction("Index", "Account");
		var model = new TLocationModel();
		LocationBL objloc = new LocationBL();
		//model.IsEmailDublicate = "0";
		JObject JLocationId = JObject.Parse(LocationId);
		IEnumerable<object> values = JLocationId.Values();
		foreach (var x in values)
		{
			//Console.WriteLine(x) or something like that to check the values of the JSON object
		}
		
		if (LocationId.Count > 0)
		{
			var Item = objloc.getLocationById(LocationId);
			if (Item != null)
			{
				model.LocationID = Item.LocationID != null ? Item.LocationID : "";
				model.Description = Item.Description != null ? Item.Description : "";
				model.Category = Item.Category != null ? Item.Category : "";
				model.Aisle = Item.Aisle != null ? Item.Aisle : "";
				model.Self = Item.Shelf != null ? Item.Shelf : "";
				model.Bin = Item.Bin != null ? Item.Bin : "";
				model.PrintBarcode = Item.PrintBarcode != null ? Item.PrintBarcode.Value : false;
			}
		}
		return PartialView("EditLocation", model);
	}
	catch (Exception ex)
	{
		throw ex;
	}
}
