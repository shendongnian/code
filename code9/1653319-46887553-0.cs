        [TestMethod]
        public void TestMethod21()
        {
            Class1 cls = new Class1();
            Assert.AreEqual("Jackie", cls.GetNewName("Jack"));
        }
        [TestMethod]
        public void TestMethod31()
        {
            Class1 cls = new Class1();
            Assert.AreEqual("Johnny", cls.GetNewName("John"));
        }
