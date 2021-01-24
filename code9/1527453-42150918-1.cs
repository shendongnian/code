    [HttpGet]        
    public string AddDeviceID(string deviceID)
    {
            User user = db.Users.Single(x => x.MobileUserName == "Dev" && x.MobilePassword == "123");
            user.MobileDeviceId = deviceID;
            db.SaveChanges();
        
            return "success";
    }  
      
