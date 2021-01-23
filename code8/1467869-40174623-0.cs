    [HttpPost]
    public JsonResult returnProperties([FromBody]string FullName) // <--- Added FromBody
    {
        try
        {
            PAVBaseDataItem node = IDE.MvcApplication.fDataProvider.RootItem.ChildItem(FullName);
            List<PAVBasePropertyItem> properties = node.PropertiesList();
            return Json(properties);
        }
        catch (Exception ex)
        {
        return Json("");
        }
    } 
