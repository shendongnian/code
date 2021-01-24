    PeopleLocationsForUserRoot peoplelocationforuser = await WebDataAccess.GetPeopleLocationForUser(UserInfoRepository.GetUserName(), _locationID);
    List<LocationPeople> users = new List<LocationPeople>();
    foreach (var user in peoplelocationforuser.locationPeople)
    {
        user.FullName = user.FirstName + " " + user.LastName;
        if(!user.contains(x => x.FullName == user.FullName)
        {
           users.Add(user);
        }
    }
