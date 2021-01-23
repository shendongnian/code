    [TestFixture]
	class GivenCustomCollectionContainsTest
	{
		const string User8 = "user8";
		const string User9 = "user9";
		private readonly List<string> users = new List<string> { "user1", "user2", "user3", "user4", "user5" };
		[Test]
		public void WhenActualContainsOneOfExpectedAndPreceededByNotOperatorThenItShouldFail()
		{
			var actual = users.ToList();
			actual.Add(User8);
			var assert = Assert.Throws<AssertionException>(() => Assert.That(actual, Does.Not.ContainsAny(User8, User9)));
			Assert.That(assert.ResultState.Status, Is.EqualTo(TestStatus.Failed));
			Assert.That(assert.Message, Does.Contain("not collection containing any of").And.Contain($"\"{User8}\""));
		}
		[Test]
		public void WhenActualContainsAllOfExpectedAndPreceededByNotOperatorThenItShouldFail()
		{
			var actual = users.ToList();
			actual.Add(User8);
			actual.Add(User9);
			var assert = Assert.Throws<AssertionException>(() => Assert.That(actual, Does.Not.ContainsAny(User8, User9)));
			Assert.That(assert.ResultState.Status, Is.EqualTo(TestStatus.Failed));
			Assert.That(assert.Message, Does.Contain("not collection containing any of").And.Contain($"\"{User8}\", \"{User9}\""));
		}
	}
