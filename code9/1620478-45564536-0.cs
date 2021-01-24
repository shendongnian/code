    var urlHelper = new UrlHelper(HttpContext.Current.Request.RequestContext);
    
    var availableOptions = new List<SelectListItem> {
        new SelectListItem {
            Text = "All",
            Value = urlHelper.Action("GetAll", "Notifications"),
            Selected = true
         },
         new SelectListItem {
            Text = "Read/Unread",
            Value = urlHelper.Action("GetReadOrUnread", "Notifications"),
            Selected = false
         },
         new SelectListItem {
            Text = "Categories",
            Value = urlHelper.Action("GetCategories", "Notifications"),
            Selected = false
         }
    };
