    public static class FluentAssertionsEx {
        public static void ShouldContainEquivalentTo<T>(this IEnumerable<T> subject, object expectation, string because = "Expected subject to contain equivalent to provided object", params object[] becauseArgs) {
            var expectedCount = subject.Count();
            var actualCount = 0;
            try {
                foreach (var item in subject) {
                    item.ShouldBeEquivalentTo(expectation);
                }
            } catch {
                actualCount++;
            }
            expectedCount.Should().NotBe(actualCount, because, becauseArgs);
        }
    }
