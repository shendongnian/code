    [DataRow("16:00", "01:00", "09:00")]
    [DataRow("16:00", "21:00", "05:00")]
    public void CalculateDuration(string open, string close, string expected) {
        var begin = TimeSpan.Parse(open);
        var end = TimeSpan.Parse(close);
        var actual = end < begin ? (TimeSpan.FromHours(24) - begin) + end : end - begin;
        Assert.AreEqual(TimeSpan.Parse(expected), actual);
    }
