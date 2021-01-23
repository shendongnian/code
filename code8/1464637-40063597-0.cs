    private GetData([parameters...])
    {
      ...
      code to get proper data
      ...
    }
    public PartialViewResult SearchPosts(string keyword)
    {
      [DataType] data = GetData([variables...]);
      return PartialView("_SearchPostsPArtial", data);
    }
    
    public JsonResult SearchPosts(string keyword)
    {
      [DataType] data = GetData([variables...]);
      return Json(data);
    }
