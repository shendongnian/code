    public void TestTimeSpan()
    {
        var ts = new TimeSpan(-1, 0, 0);
        var s = string.Format("{0}{1:hh\\:mm}", ts < TimeSpan.Zero? "-": string.Empty, ts);
        Assert.AreEqual("-1:00", s);
    }
