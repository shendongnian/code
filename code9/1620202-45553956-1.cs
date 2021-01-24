    // to make it work i had to move
    
    List<string>[] HANGOUT_USER_LIST = new List<string>[4];
    
    // to outside the constructor of the class, and make internal.
    
    public List<string>[] Select()
    {
    // had to move it from inside here. to above it ^^^
    }
    // then in the form im using with the listboxes in i had to make this call.
    xUSERLIST.DataSource = DeltaDataInterface.HANGOUT_USER_LIST[1];
    xPASSLIST.DataSource = DeltaDataInterface.HANGOUT_USER_LIST[2];
    xMAILLIST.DataSource = DeltaDataInterface.HANGOUT_USER_LIST[3];
    xUIDLIST.DataSource = DeltaDataInterface.HANGOUT_USER_LIST[0];
    
    // [0] gets the userid
    // [1] gets the usernames
    // [2] gets the passwords
    // [3] gets the email.
