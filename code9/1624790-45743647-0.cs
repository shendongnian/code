    public class BlogEntryViewModel 
    {
        // any other properties you need
        public string TitleUrl { get; set; }
    }
    public JsonResult GetBlogEntries(MarkerOfPlace placeMarker)
    {
        try
        {
            var blogEntries = _blogEntryRepo.GetAll(x => x.IsActive.Value && x.PlaceMarkerID == placeMarker.Id)
            .Select(e => new BlogEntryViewModel {
                TitleUrl = MVCHelper.RouteHelper.MakeSeoUrl(e.Title),
                // other properties here
            })
            .ToList();                
            return Json(new { Success = true, BlogEntries = blogEntries});
        }
        catch (Exception ex)
        {
            return Json(new { Success = false, Message = ex.Message });
        }
    }
