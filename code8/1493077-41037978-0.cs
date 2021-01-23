        [TestMethod]
        public void MyTestMethod()
        {
            TaskEx.Run(async () =>
            {
                //Replace with unit test code
                await TaskEx.Delay(1000);
            }).GetAwaiter().GetResult();
        }
