    public class MultithreadedStringTest
    {
        private string _sharedString;
        [TestMethod]
        public void DoesntMessUpStrings()
        {
            var inputStrings = "The quick fox jumped over the lazy brown dog".Split(' ');
            var random= new Random();
            Parallel.ForEach(Enumerable.Range(0, 1000), x =>
            {
                _sharedString += " " + inputStrings[random.Next(0, 9)];
            });
            var outputStrings = _sharedString.Trim().Split(' ');
            var nonMangledStrings = outputStrings.Count(s => inputStrings.Contains(s));
            Assert.AreEqual(1000, outputStrings.Length, 
                $"We lost {1000-outputStrings.Length} strings!");
            Assert.AreEqual(nonMangledStrings, outputStrings.Length, 
                $"{outputStrings.Length-nonMangledStrings} strings got mangled.");
        }
    }
