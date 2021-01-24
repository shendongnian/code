    var userList = new List<User>();
    IGraphServiceUsersCollectionPage pagedCollection = await graphClient.Users.Request().Select("Department,Mail,Display,Id,GivenName,Surname,UserPrincipleName").GetAsync();
    if (pagedCollection != null)
    {
        do
        {
            List<User> usersList = pagedCollection.CurrentPage.ToList();
            foreach (var user in usersList)
            {
                userList.Add(user);
            }
            pagedCollection = await pagedCollection.NextPageRequest.GetAsync();
        } while (pagedCollection != null);
    }
