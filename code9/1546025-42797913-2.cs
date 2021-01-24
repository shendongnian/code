    [Test]
    public void Test_Registry_Writes_Correct_Values()
    {
         string key = "foo";
         string value = "bar";
         // you would normally do this next bit in the Setup method or test class constructor rather than in the test itself
         Mock<IRegistryActions> mock = MockFramework.CreateMock<IRegistryActions>();
        var classToTest = new ExampleClass(mock); // some frameworks make you pass mock.Object
        
        // Tell the mock what you expect to happen to it
        mock.Expect(m => m.WriteValue(key, value));
       // Call the action:
       classToTest.WriteValue(key, value);
       // Check the mock to make sure it happened:
       mock.VerifyAll();
    }
