    var db = FirebaseDatabase.DefaultInstance.RootReference;
    var profileRef = db.Child("profiles/MyProfileKey");
	profileRef.GetValueAsync().ContinueWith(t =>
	{
        var values = t.Result.Value as System.Collections.Generic.Dictionary<string, object>;
        // Let the constructor populate the fields
		Profile profile = new Profile(values)
		{
		    profileKey = profileRef.Key
		};
        DateTime createdDate = profile.utcCreated;
	});
