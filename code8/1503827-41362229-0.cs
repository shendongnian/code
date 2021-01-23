    [Route("api/User/PostUserFavorite/{id_cd}/{UserId}")]
    public async Task PostUserFavorite(int id_cd, string UserId)
    {
        User_FavoriteCd newEntry = new User_FavoriteCd();
        newEntry.id_id = id_cd;
        newEntry.datetime = DateTime.Now;
        newEntry.UserId = UserId;
        db.User_FavoriteCd.Add(newEntry);
        await db.SaveChangesAsync();
    }
