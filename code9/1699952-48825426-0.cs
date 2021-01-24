    public class TestCases
    {
            public TestCases(string elementTag, string id, string xpath, string textToMatch)
            {
                ElementTag = elementTag;
                Id = id;
                XPath = xpath;
                TextToMatch = textToMatch;
            }
            public string ElementTag { get; set; }
            public string Id { get; set; }
            public string XPath { get; set; }
            public string TextToMatch { get; set; }
    }
