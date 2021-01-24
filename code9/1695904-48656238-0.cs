      public interface IFoo
        {
            void SayHello(string to);
        }
        [Test]
        public void SayHello()
        {
            var cals = new List<string>();
            var foo = Substitute.For<IFoo>();
            foo.When(x => x.SayHello(Arg.Any<string>()))
                .Do(x =>
                {
                    cals.Add(x[0].ToString());// use the indexer
                });
            foo.SayHello("World");
            Assert.AreEqual(cals[0], "World");
        }
