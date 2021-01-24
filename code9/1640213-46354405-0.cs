    public IList<Thing> GetThings (ApplicationUser user)
    {
        // just an example…
        return Things.Where(t => t.UserId == user.Id).ToList();
    }
