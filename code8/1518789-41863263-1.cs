    [TestMethod]
        public void Get_Foo_From_Controller()
        {
            var fooController = new FooController();
            var result = fooController.Get();
            //Here we are casting the expected type
            var values = (OkNegotiatedContentResult<string>)result;
            Assert.AreEqual("Foo", values.Content);
        }
