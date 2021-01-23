    [Test]
        public void it_should_throw_exactly()
        {
            Action actionToTest = () => { throw new MyException(); };
            actionToTest.ShouldThrowExactly<MyException>();
        }
        [Test]
        public void it_should_throw()
        {
            Action actionToTest = () => { throw new MyException(); };
            actionToTest.ShouldThrow<Exception>();
        }
