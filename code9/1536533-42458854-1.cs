    public PartialViewResult GetAthleteVideo(int AthleteID)
    {
        var vidModels = new AthleteVideoViewModel();
        vidModels.AthleteDbList = PopulateVideosWithAthleteID(AthleteID);
        return PartialView("_ShowAthlete", vidModels);
    }
