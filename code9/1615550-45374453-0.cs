        [TestMethod]
        public void TestFoo()
        {
            var obj = new SomeClass(() => DateTime.Now);
            //Only true on sundays
            Assert.IsTrue(obj.Foo());
            //This is sunday
            obj = new SomeClass(() => new DateTime(2017, 7, 30));
            //This will be always true
            Assert.IsTrue(obj.Foo());
            //This is not sunday
            obj = new SomeClass(() => new DateTime(2017, 7, 29));
            //This will be always false
            Assert.IsFalse(obj.Foo());
        }
