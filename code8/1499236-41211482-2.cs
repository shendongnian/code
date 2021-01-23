    public ActionResult BuildCommentTable()
    {
         ViewBag.AnnouncementOptions= new SelectList(db.Announcements, "AnnouncementId", "AnnouncementContent");
         var comments = db.Comments.Include(c => c.Announcement);
         return PartialView("_CommentTable", GetMyComments());
    }
