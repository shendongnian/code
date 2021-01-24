    public void ResisterButton ()
    {    
        if (Username != "")
        {           
            StartCoroutine(CheackDBUN(Username,
                (userDataString) =>
                {
                    Debug.LogWarning("User Data String in ResisterButton " + userDataString); 
                    // do stuff with text eg turn bool UN = true
                }
                ));
        }
    }
