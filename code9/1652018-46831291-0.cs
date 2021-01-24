    [TestMethod]
    [ExpectedException(typeof(<<Your expected exception here>>))]
    public void GetSystem_SystemDoesntExist() {
        var bll = new LicensingApplicationServiceBusinessLogic();
        bll.GetSystem(613);
    }
