        [TestMethod]
        public async Task Test()
        {
            var task = Task.CompletedTask;
            var a = new Mock<A>();
            a.Setup(x => x.FooAsync()).Returns(task).Raises(x => x.Created += null, EventArgs.Empty);
            a.Object.Created += (s, e) =>
            {
            };
            await a.Object.FooAsync();
        }
