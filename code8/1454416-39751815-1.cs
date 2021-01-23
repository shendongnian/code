        private static void VerifyAssertions(Assertion[] assertions)
        {
            var failedAssertions = assertions.Where(a => !a.IsMatch()).ToArray();
            if (failedAssertions.Any())
            {
                throw new AssertFailedException(string.Join<Assertion>("; ", failedAssertions));
            }
        }
