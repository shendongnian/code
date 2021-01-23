     var userInfo = userMangerMock.GetUser("TestManager");
    
        bool passWordMatch = userMangerMock.ChePassword(userInfo.Id, userInfo.Password);
        
        Assert.AreEqual(true, passWordMatch);
