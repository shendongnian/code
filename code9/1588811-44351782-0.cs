    //assuming you get string URL. Change type as per need.
    string reqdURL = GetServiceURL(typeof(userObject));
    
    private string GetServiceURL(Type userType)
    {
        if (userType == typeof(UserType1))
        {
            // currently hardcoded but you can replace your own fetch logic
            return "localhost:6227/Service1.svc";
        }
        if (userType == typeof(UserType2))
        {
            return "localhost:6227/Service2.svc";
        }
        //and so on
    }
