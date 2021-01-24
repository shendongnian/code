    [HttpPost]
    public JsonResult GetGroupFriendsLists(int groupid)
    {
        var grp = db.Groups.Where(k => k.GroupId == groupid).Any();
        if (!grp)
        {
            return Json(new ApiResponse
            {
                Message = "Invalid group inforamtion.",
                Status = false
            }, JsonRequestBehavior.AllowGet);
        }
        var lists = db.Groups.Where(k => k.GroupId == groupid).Select(k => k.SharedLists).FirstOrDefault().Where(k => k.ListType == SharedListTypes.Friends && (k.ExpiryDate == null || k.ExpiryDate.Value.Date > DateTime.Now.Date)).Select(
            k =>
            new
            {
                k.CreatorId,
                ExpiryDate = HelperFunctions.DateTimeFormattedString(k.ExpiryDate),
                k.ListId,
                k.ListName,
                k.ListType,
                TimeStamp = HelperFunctions.DateTimeFormattedString(k.TimeStamp),
                ItemsCount = k.ListItems.Count
            }).ToList();
        if (lists.Count <= 0)
        {
            return Json(new ApiResponse
            {
                Status = false,
                Message = "No friends lists in this group."
            }, JsonRequestBehavior.AllowGet);
        }
        return Json(new ApiResponse
        {
            Status = true,
            Message = "We found the friends shared lists of this group.",
            Data = lists
        }, JsonRequestBehavior.AllowGet);
    }
