    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult SubmitStory(AddStoryViewModel model, HttpPostedFileBase StoryImg) 
    {
         // other stuff
         if (StoryImg != null)
         {
             String fileName = String.Format("{0}.jpg", new Guid());
             StoryImg.SaveAs(Server.MapPath("~/img/") + fileName);
             newStory.StoryImage = fileName;         
         }
         // other code to add story data into DB
         return RedirectToAction("Success", new { storyID = newStory.StoryID });
    }
