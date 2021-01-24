        [Fact]
        public void TestPostCollectionName()
        {
            valData = new ValData();
            valData.value = "NewObject";
            controller = SetupController();
            var results = controller.PostCollectionName(valData, testCollecName);
            Assert.NotNull(results);
            Assert.True(controllerContext.HttpContext.Response.StatusCode == 200);
        }
