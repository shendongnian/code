        [TestMethod]
        public void SomeTest()
        {
            var theAs = new List<A>
            {
                new A{ AId=1, Name="test" }
            };
            var theBs= new List<B>
            {
                new B{ BId=1, AId=1, theA=theAs[0] }
            };
            //here
            theAs[0].theB = theBs
    
            var ASet= new Mock<DbSet<A>>().SetupData(theAs);
            var BSet= new Mock<DbSet<B>>().SetupData(theBs);
    
            var context = new Mock<MyContext>();
            context.Setup(s => s.A).Returns(ASet.Object);
            context.Setup(s => s.B).Returns(BSet.Object);
    
            var m = new ClassThatImTesting(context);
            m.someMethod("test");
        }
