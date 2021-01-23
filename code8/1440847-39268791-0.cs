        public class TestIndexer
        {
            public string x;
            public int y;
            public object this[int i]
            {
                get
                {
                    switch (i)
                    {
                        case 1:
                            return y;
                        case 2:
                            return x;
                        default:
                            return "";
                        // return the property you want based on index i
                    }
                }
            }
        }
        TestIndexer t = new TestIndexer();
        t.y = 22;
        object indexValue = t[1]; //22
