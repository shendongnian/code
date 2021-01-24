    public String GetStoredCredentials
    {
        get { 
            string value = NSUserDefaults.StandardUserDefaults.StringForKey("Key"); 
            if (value == null)
                return "";
            else
                return value;
        }
        set {
            NSUserDefaults.StandardUserDefaults.SetString(value.ToString (), "Key"); 
            NSUserDefaults.StandardUserDefaults.Synchronize ();
        }
    }
