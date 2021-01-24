            [TestMethod]
            public async Task TestMethod1()
            {
                Myclass tempClass = new Myclass();
                await tempClass.CreateImage();
                Assert.AreEqual(3, tempClass.Sum);
            }
