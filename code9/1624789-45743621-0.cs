    public JsonResult GetBlogEntries(MarkerOfPlace placeMarker)
    {
        try
        {
            var blogEntries = _blogEntryRepo
                .GetAll(x => x.IsActive.Value && x.PlaceMarkerID == placeMarker.Id)
                .Select(x => new
                {
                    ... Map BlogEntry's other properties here
                    Title = x.Title,
                    SeoUrl = MVCHelper.RouteHelper.MakeSeoUrl(x.Title)
                })
                .ToList();
    
            return Json(new { Success = true, BlogEntries = blogEntries });
        }
        catch (Exception ex)
        {
            return Json(new { Success = false, Message = ex.Message });
        }
    }
