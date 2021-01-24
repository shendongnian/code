    class Program
    {
        static void Main(string[] args)
        {
            var _streamWriterMock = new Mock<StringWriter>();
            string[] expectedLines= new []{"test","test"};
            foreach (var expectedLine in expectedLines)
            {
                _streamWriterMock.Object.Write(expectedLine);
            }
            foreach (var line in expectedLines)
            {
               _streamWriterMock.Verify(a=>a.Write(line),Times.Exactly(1));    
            }
                     
        }
    }
