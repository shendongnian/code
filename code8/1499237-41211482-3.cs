    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult AjaxCreate([Bind(Include = "CommentId,CommentContent,AnnouncementId")] Comment comment)
    {
        if (ModelState.IsValid)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
        }
    
        ViewBag.AnnouncementOptions = new SelectList(db.Announcements, "AnnouncementId", "AnnouncementContent", comment.AnnouncementId);
        return PartialView("_CommentTable", db.Comments.Include(c => c.Announcement));
    }
