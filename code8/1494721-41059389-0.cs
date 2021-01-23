    TestAbstractionLib.UnitTestUtilsClass.UnitTestFileName = TestAbstractionLib.UnitTestUtilsClass.VisualDumpAfterValueSet;
    object[] prop = { "Patient", false };
    var methodUnderTest = Helper.GetStaticMethod(typeof(TestAbstractionLib), "GetListOfDesiredNodes");
    var labelNode = methodUnderTest.Invoke(this, prop) as List<XmlNode>;
    
    
    object[] prop1 = {labelNode.FirstOrDefault(), "BIPOLAR", "Chamber", true, 10, 10, false};
    methodUnderTest = Helper.GetStaticMethod(typeof(TestAbstractionLib), "CheckValueIsSetAlready");
    var result = methodUnderTest.Invoke(this, prop1);
    
    Assert.AreEqual(result, false);
    TestAbstractionLib.UnitTestUtilsClass.CheckerrorinLogFile(true);
