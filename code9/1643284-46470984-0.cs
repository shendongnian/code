    [Fact]
    public async Task TestGetNameById()
    {
        string expectedName = "Component";
        using (var context = GetContextWithData())
        {
            var controller = new AssetTypesController(context);
            var result = await controller.Details(2) as ViewResult;
            var assetType = (AssetType) result.ViewData.Model;
            Assert.Equal(expectedName, assetType.Name);
        }
    }
