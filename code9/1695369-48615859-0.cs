     [TestMethod]
        public void TestAPIShowInfoIsNull()
        {
            //arrange
            var controller = new ShowsInfoController();
            controller.ControllerContext = new ControllerContext();
            controller.ControllerContext.HttpContext = new DefaultHttpContext();
            var response = controller.ControllerContext.HttpContext.Response;
            //act
            ShowsInfo showsInfo = null;
            var result = controller.API(showsInfo);
            //assert
            Assert.AreEqual(400, response.StatusCode);
            Assert.IsInstanceOfType(result, typeof(JsonResult));
        }
