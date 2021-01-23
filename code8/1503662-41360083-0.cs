        [Test]
        public void FindByName_WhenPassedUserName_ReturnsSLUserWithUserName()
        {
            var myClassBeingTested = "";//create an instance of the class being tested
            var mockSLUserManager = "";//create a mock version of SLUserManager 
            myClassBeingTested.UserManager = mockSLUserManager;
            var userName = "mark_h";
            var expected = mockSLUserManager.FindByName(userName);
            var result = myClassBeingTested.FindByName(userName);
            Assert.AreEqual(expected, result);
        }
