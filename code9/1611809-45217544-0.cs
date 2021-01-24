    public class TestClass : IDisposable
    {
        private string _directory;
        public TestClass()
        {
            _directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            Directory.CreateDirectory(_directory);
        }
        [Fact]
        public void NoFiles()
        {
            Assert.Empty(GetAvailableFiles(_directory));
        }
        [Fact]
        public void TwoFiles()
        {
            File.WriteAllText(Path.Combine(_directory, "aaa.txt"), "");
            File.WriteAllText(Path.Combine(_directory, "bbb.txt"), "");
            var files = GetAvailableFiles(_directory);
            Assert.Equal(2, files.Length);
            Assert.Contains(Path.Combine(_directory, "aaa.txt"), files);
            Assert.Contains(Path.Combine(_directory, "bbb.txt"), files);
        }
        public void Dispose()
        {
            Directory.Delete(_directory, true);
        }
        // Method under test
        public string[] GetAvailableFiles(string rootFolder)
        {
            return Directory.GetFiles(rootFolder);
        }
    }
