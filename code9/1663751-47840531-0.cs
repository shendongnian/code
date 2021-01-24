        [Test]
        public void ShouldReturnAValuOnSubscribe()
        {
            var testScheduler = new TestScheduler();
            var testableObserver = testScheduler.CreateObserver<int>();
            var reactiveProperty = new ReactiveProperty<int>(30);
            reactiveProperty.Subscribe(testableObserver);
            Assert.AreEqual(30, testableObserver.Messages.Single().Value.Value);
        }
