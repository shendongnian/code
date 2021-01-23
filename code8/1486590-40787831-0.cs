        [Test]
        public void TestMatch()
        {
            // Arrange.
            const string example = "123 écumé 456";
            Regex pattern = new Regex(@"\bécumé\b");
            // Act.
            Match match = pattern.Match(example);
            // Assert.
            Assert.That(match.Success, Is.True);
        }
