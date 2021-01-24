    [TestMethod]
    public void VerifyAmountTest()
    {
       //Using PrivateObject class
       PrivateObject privateHelperObject = new PrivateObject(typeof(Project));
       double amount = 500F;
       bool expected = true;
       bool actual;
       actual = (bool)privateHelperObject.Invoke("VerifyAmount", amount);
       Assert.AreEqual(expected, actual); 
     }
