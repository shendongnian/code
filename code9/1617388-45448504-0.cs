    [TestMethod()]
        public void IsEquivalentTest()
        {
            Assert.IsTrue(Program.IsEquivalent(false, false));
            Assert.IsTrue(Program.IsEquivalent(false, true));
            Assert.IsTrue(Program.IsEquivalent(true, false));
            Assert.IsTrue(Program.IsEquivalent(true, true));
        }
