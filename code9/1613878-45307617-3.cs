    public void ExecuteTestcase(IEnumerable<XElement> theTestCaseNodes)
    {
        foreach(var node in theTestCaseNodes)
        {
            using (var reader = node.CreateReader())
            {
                // use XmlReader for testing
            }
        }
    }
