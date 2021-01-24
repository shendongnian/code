    [TestMethod]
    public void _Checking_Dictionary_Is_Able_To_Update() {
        // Arrange
        var inputDictionary = new Dictionary<string, string>();
        inputDictionary.Add("key1", "someValueForKey1");
        inputDictionary.Add("key2", "someValueForKey2");
        string inputKeyValue = "key1";
        string dataToUpdate = "updatedValueForKey1";
        // Act
        inputDictionary.AddOrUpdate(inputKeyValue, dataToUpdate);
        // Assert
        //...
    }
