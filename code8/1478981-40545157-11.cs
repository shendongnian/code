        [TestMethod]
        public void ChildClassPropertyChanged()
        {
            var bc = new BaseClass();
            var c = new MyClassViewModel();
            bc.Title = "t1";
            c.myClassBase = bc;
            Assert.AreEqual("t1", c.Title);
            c.Title = "t2";
            Assert.AreEqual("t2", c.Title);
            c.myClassBase.Title = "t3";
            Assert.AreEqual("t3", c.Title);
            c.myClassBase = new BaseClass();
            bc.Title = "t4";
            Assert.AreEqual(null, c.Title);
            c.myClassBase.Title = "t5";
            Assert.AreEqual("t5", c.Title);
        }
