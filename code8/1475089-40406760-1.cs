    [TestFixture]
    public class Test
    {
        [Test]
        public void Compare()
        {
            IDictionary<string, double> dictionaryOne = new Dictionary<string, double>()
            {
                {"he", 0},{"ey", 0 }
            };
            Dictionary<string, double> dictionaryTwo = new Dictionary<string, double>()
            {
                {"he", 0},{"ey", 0 },{"yg", 0 },{"gu", 0 },{"uy", 0 },{"ys", 0 }
            };
            var comparer = new DictionaryComparer();
            var list = comparer.CompareDictionaries(dictionaryOne, dictionaryTwo);
            Assert.That(4, Is.EqualTo(list.Count));
            Assert.That("yg", Is.EqualTo(list[0]));
            Assert.That("gu", Is.EqualTo(list[1]));
            Assert.That("uy", Is.EqualTo(list[2]));
            Assert.That("ys", Is.EqualTo(list[3]));
        }
    }
