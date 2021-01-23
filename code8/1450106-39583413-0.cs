        //method under test
        public int CallRef()
        {
            double d1 = 10;
            var r1 = _foo.DoRef(ref d1);
            return r1;
        }
        //test method
        [TestMethod]
        public void TestMethod1()
        {
            double dt = 10;
            var fooStub = new Mock<IFoo>();
            fooStub.Setup(x => x.DoRef(ref dt)).Returns(7);
            var s = new S(fooStub.Object);
            var r1 = s.CallRef(); 
        }
       
