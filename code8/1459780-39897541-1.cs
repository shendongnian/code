    [TestMethod]
    public void Status_Code_Gets_Set_To_Unauthorized() {
        //Arrange
        var json = "{\"person\": {\"password\":\"abc123\", \"username\":\"user\", \"name\":\"test person\"}}";
        var controller = new HubspotController();
        //Act
        var actionResult = controller.FreeDemo(json) as HttpStatusCodeResult;
        //Assert
        Assert.IsNotNull(actionResult);
        Assert.AreEqual((int)HttpStatusCode.Unauthorized, result.StatusCode);
    }
