        [TestCaseSource(nameof(ShouldThrowArgumentSource))]
        public void ShouldThrowArgumentException(string path)
        {
            // Act
            ActualValueDelegate<object> testDelegate = () => _import.LoadBatchFile(path);
            // Assert
            Assert.That(testDelegate, Throws.TypeOf<ArgumentNullException>());
        }
        private static IEnumerable ShouldThrowArgumentSource()
        {
            yield return string.Empty;
            yield return null;
        }
