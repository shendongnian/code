    [TestMethod]
    public void SampleTest()
    {
        using (ShimsContext.Create())
        {
            // Arrange
            SqlConnection.AllInstances.BeginTransactionIsolationLevel =
                (instance, iso) => { ... };
    
            // Act
    
            // Assert
        }
    }
