        [TestMethod]
        public void TestMethod1()
        {
            var definitions = new Dictionary<MethodType, Func<object[], IRequest>>
            {
                {
                    MethodType.T1, objects =>
                    {
                        var testRequest = new TestRequest();
                        return testRequest.Method1((string)objects[0], (int)objects[1]);
                    }
                },
                {
                    MethodType.T2, objects =>
                    {
                        var testRequest = new TestRequest();
                        return testRequest.Method2((string)objects[0], (int)objects[1], (string)objects[2]);
                    }
                }
            };
            var testClass = new TestClass(definitions);
            var result1 = testClass.MethodGenerator(MethodType.T1, "test", 1);
            var result2 = testClass.MethodGenerator(MethodType.T2, "test2", 1, "test2");
            Assert.AreEqual("Request1", result1.RequestName());
            Assert.AreEqual("Request2", result2.RequestName());
        }
