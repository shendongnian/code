    [TestMethod]
    public void RegisterMethodTest()
    {
        var p = new Patient();
        Patient.patientInfo info;
        info.firstName = ...
        // What I want to use the struct for but gives error:  
        Assert.IsFalse(p.Register(info));    
    }
