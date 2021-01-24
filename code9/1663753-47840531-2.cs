        [Test]
        public void ShouldNotReturnAnInitialValue_WhenModeIsNone_AndOnSubscribe()
        {
            var testScheduler = new TestScheduler();
            var testableObserver = testScheduler.CreateObserver<int>();
            var reactiveProperty = new ReactiveProperty<int>(30, ReactivePropertyMode.None);
            reactiveProperty.Subscribe(testableObserver);
            Assert.IsEmpty(testableObserver.Messages);
        }
