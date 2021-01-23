    if (sr != null)
    {
        if(sr.Properties["objectCategory"] != null)
        {
           // objectType will be "Person" or "Group" (or something else entirely)
           string objectType = sr.Properties["objectCategory"][0].ToString();
           if (objectType == "Person")
           { 
              //It's a user
           }
           if (objectType == "Group")
           { 
              //It's a Group
           }
        }
    }
