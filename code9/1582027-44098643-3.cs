    [TestMethod]
    public void FindsSubstringsCommonToEachInputString()
    {
        var subject = new UnknownSubstringFinder();
        var input = new string[]{"HelloFromWorld","WorldFromHello","FromWorldHello"}
        var output = subject.FindCommonSubstrings(input, 5).ToList();
        assert.IsTrue(output.Contains("Hello"));
        assert.IsTrue(output.Contains("World"));
        assert.AreEqual(2, output.Count); // ensure no other matches
    }
