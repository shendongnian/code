    public IHttpActionResult SavePlayerLoc(IEnumerable<int> playerLocations) {
        int userId = User.Identity.GetUserId<int>();
        bool isSavePlayerLocSaved = sample.SavePlayerLoc(userId, playerLocations);
        return Ok(isSavePlayerLocSaved );
    }
