        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                throw new CustomException("aaa", "bla bla");
            }
            catch(CustomException ex)
            {
                //some assert condition with proper message
                Assert.AreEqual(ex.Message, "some Stuff", "My message");
            }
        }
