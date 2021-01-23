    public void Page_Load()
    {
        // Retrieve authenticated user information
        UserClass userObject = GetUserCredentials();
        // Call a method that turns the authenticated user object into a string that contains the users session information. Given the sensivity of this information, might want to try to encrypt it or offuscate it. Store it in a session variable as a string
        Session["UserContext"] = userObject.SerializeUser()
        /* rest of the page code goes here */
    }
    [WebMethod(EnableSession=true)]
    public static void CreateJob()
    {
        Submit_Job();
    }
    
    public static void Submit_Job()
    {
        // Lets get the authenticated user information through the session variable. Due to the static nature of the method, we can't access the Session variables directly, so we call it using the current HttpContext
        string serializedUserInfo = )HttpContext.Current.Session["UserContext"].ToString();
       // Let's create the users object. In my case, we have a overcharged constructor that receives the users serialized/encrypted information, descrypts it, deserializes it, and return a instance of the class with the deserialized information
       UserClass userObject = new UserClass(serializedUserInfo);
       // Do whatever the method has to do now!
    }
