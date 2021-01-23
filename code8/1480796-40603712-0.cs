        [TestCase("-Username ABC -Password XYZ -Address MNO", "-Username ABC -Password *** -Address MNO")]
        public void Test(string toTest, string expected ) 
        {
            Assert.AreEqual(expected, DestroyPassword(toTest));
        }
