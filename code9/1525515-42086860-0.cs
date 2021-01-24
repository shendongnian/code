    PeopleLocationsForUserRoot peoplelocationforuser = await WebDataAccess.GetPeopleLocationForUser(UserInfoRepository.GetUserName(), _locationID);
    // create a temporary dictionary
    var tempDic = new Dictionary<string, LocationPeople>();
    foreach (var user in peoplelocationforuser.locationPeople)
    {
        user.FullName = user.FirstName + " " + user.LastName;
        // check the dictionary before adding
        if (!tempDic.ContainsKey(user.FullName))
        {
            tempDoc.Add(user);
        }
    }
    // once I have my dictionary, I can make a list
    var users = new List<LocationPeople>(tempDic.Values);
