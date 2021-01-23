    [Test]
    public void MyTest()
    {
      var conf = new Dictionary<string, string>();
      var _mockMgmt = MockRepository.GenerateMock<Management>();
      // TODO - Set expectations on _mockMgmt here, since the SMin constructor uses it
      // Create instance of SMin, passing in our mock
      var smin = new SMin(conf, _mockMgmt);
      // TODO - More test code, followed by assertions
    }
