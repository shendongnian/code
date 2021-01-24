    public static class ClassData
        {
            public static string GetData()
            {
                //Wish to mock TestResult method
                TestData td = new TestData();
                string finalResult = td.TestResult();
                //Some logic
                return finalResult;
            }
        }
        [TestMethod, Isolated]
        public void Test_MockFinalResult()
        {
            var fakeTestData = Isolate.Fake.NextInstance<TestData>();
            Isolate.WhenCalled(() => fakeTestData.TestResult()).WillReturn("test");
            var str = ClassData.GetData();
            Assert.AreEqual("test",str);
        }
