        [Test]
        public void ShouldReturnAValuOnToReactiveProperty()
        {
            var testScheduler = new TestScheduler();
            var testableObserver = testScheduler.CreateObserver<int>();
            var reactiveProperty = Observable.Never<int>().ToReactiveProperty(40);
            reactiveProperty.Subscribe(testableObserver);
            Assert.AreEqual(40, testableObserver.Messages.Single().Value.Value);
        }
