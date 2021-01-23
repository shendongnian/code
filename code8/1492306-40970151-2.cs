    public IHttpActionResult Get([FromUri] int[] idList)
    {
        if (idList != null) // use optional filter is it present in uri
            return Json(idList.Select(i => $"value{i}")); 
        // return all items by default
        return Json(new[] { "value1", "value2", "value3" });
    }
    
