    var acceptLanguages = new string[] { "it-IT","en-US", };
    var fields = FieldSelector.For<Person>()
                .WithId()
                .WithFirstName()
                .WithLastName()
                .WithFormattedName()
                .WithEmailAddress()
                .WithHeadline()
                .WithLocationName()
                .WithLocationCountryCode()
                .WithPictureUrl()
                .WithPublicProfileUrl()
                .WithSummary();
    Person profile = api.Profiles.GetMyProfile(user,acceptLanguages,fields);
