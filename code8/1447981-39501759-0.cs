    [TestCase(101d, true)]
    [TestCase(100d, false)]
    public void SutConfirmsIfNumberIsPalindrome(double input, bool expectedOutcome) {
      var outcome = isPalindrome(input);
      Assert.True(outcome == expectedOutcome);
    }
