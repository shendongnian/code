    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult UploadCompetitionPicture([Bind(Exclude = "CompetitionPicture")]PhotoCompetition model)
    {
        string croppedImage = Request.Form["photoCompetitionCroppedPicture"];
        byte[] imageBytes = Convert.FromBase64String(croppedImage);
        var userId = User.Identity.GetUserId();
        var participation = new PhotoCompetition
        {
            UserID = User.Identity.GetUserId(),
            FirstName = "Ken",
            Email = User.Identity.GetUserName(),
            TermsAndConditionsAccepted = true,
            TimeStamp = DateTime.UtcNow.ToUniversalTime(),
        };
        participation.CompetitionPicture = imageBytes;
        DB.PhotoCompetition.Add(participation);
        DB.SaveChanges();
        return View("Edit");
    }
