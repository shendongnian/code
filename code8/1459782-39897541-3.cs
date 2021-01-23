    [TestMethod]
    public void Status_Code_Gets_Set_To_Unauthorized() {
        //Arrange
        var json = "{\"person\": {\"password\":\"abc123\", \"username\":\"user\", \"name\":\"test person\"}}";
        var controller = new HubspotController();
        var expected = (int)HttpStatusCode.Unauthorized;
        //Act
        var actionResult = controller.FreeDemo(json) as HttpStatusCodeResult;
        //Assert
        Assert.IsNotNull(actionResult);
        Assert.AreEqual(expected, actionResult.StatusCode);
    }
