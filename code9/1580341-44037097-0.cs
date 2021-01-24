    [TestClass]
    public class DisposableTests
    {
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void DoesntDisposeStreamWriter()
        {
            var filename = CreateFile();
            var fs = new StreamWriter(filename);
            fs.WriteLine("World");
            var fs2 = new StreamWriter(filename);
            fs2.WriteLine("Doesn't work - the file is already opened.");
        }
        [TestMethod]
        public void DisposesStreamWriter()
        {
            var filename = CreateFile();
            var fs = new StreamWriter(filename);
            fs.WriteLine("World");
            fs.Dispose();
            var fs2 = new StreamWriter(filename);
            fs2.WriteLine("This works");
            fs2.Dispose();
        }
        private string CreateFile()
        {
            var filename = Guid.NewGuid() + ".txt";
            using (var fs = new StreamWriter(filename))
            {
                fs.WriteLine("Hello");
            }
            return filename;
        }
    }
