    public void SomeMethod(string name)
    {
        // validate name here, for example name may not be empty
        if (String.IsNullOrWhiteSpace(name))
        {
            return; // stop executing method because name is not valid
        }
        // do stuff for which a valid name is needed
        // ...
    }
