    MemberResponse memberResponse = .... // your code that calls the API
    // enumerate members
    foreach (var member in memberResponse.Members)
    {
        // enumerate merge fields
        foreach (var key in member.merge_fields.Keys)
        {
            // when key = "FNAME", value would be the first name of the member
            // when key = "LNAME", value would be the last name of the member
            string value = member.merge_fields[key].ToString();
        }
        // enumerate interests
        foreach (var key in member.interests.Keys)
        {
            // when key = "9143cf3bd1", value would be true
            // when key = "3a2a927344", value would be false
            // ... and so on
            bool value = member.interests[key];
        }
    }
