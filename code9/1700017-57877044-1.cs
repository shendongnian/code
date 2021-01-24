        [TestCase("", ExpectedResult = typeof(ArgumentException))]
        [TestCase(null, ExpectedResult = typeof(ArgumentNullException))]
        public Type ReturnStatusInvalidArgument(string filePath)
        {
            return Assert.Catch(() => Method(filePath)).GetType();
        }
