    [TestClass]
    public class ConcurrentDictionaryTests
    {
        [TestMethod]
        public void DoesntMakeContentsThreadsafe()
        {
            var s = "1010101010101010101010101010101010101010";
            var dictionary = new ConcurrentDictionary<int, ClassWithProperty>();
            dictionary.TryAdd(1, new ClassWithProperty());
            Parallel.ForEach(s, c => dictionary[1].TheString += c);
            Assert.AreEqual(s.Length, dictionary[1].TheString.Length);
        }
    }
    public class ClassWithProperty
    {
        public string TheString { get; set; }
    }
