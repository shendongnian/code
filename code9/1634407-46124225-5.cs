    private async Task CheckUntilOneOfTheUsersIsAvaliable()
    {
        await Task.WhenAny(Enumerable.Range(0, 10)
            .Select(i => CheckUntilUserIsAvaliable()));
        //Work to be done when any one of the checking operations has indicated that it's avalaible
    }
