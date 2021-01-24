    public static int GetAllFavoritesByCreatorID(string creatorID)
    {
        using (var Context = GetContext())
        {
            return Context.Favorites.Where(x => x.CreatorID == creatorID).Count();
        }
    }
