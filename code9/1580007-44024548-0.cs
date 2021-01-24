        public class TestClass
        {
            public static TestClass CreateWithValidData(byte[] somedata)
            {
                if (somedata == null || somedata.Length < 1322)
                  return null;
                return new TestClass (somedata );
            }
            
            private Int32 aValue;
            public TestClass(byte[] somedata)
            {
                // Here we do something with somedata
                // e.g. extract some values from some bytes
                aValue = somedata[1321] + 256 * somedata[1321];
            }
        }
    
