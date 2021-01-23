    [TestMethod]
    public void DateTimeToInt32()
    {
        var dateTimePattern = "yyyyMMdd";
        int numericDateTime = Convert.ToInt32(DateTime.Today.ToString(dateTimePattern));
        DateTime dateTimeFromInt32 = DateTime.ParseExact(numericDateTime.ToString(), dateTimePattern, CultureInfo.InvariantCulture);
        Assert.AreEqual(dateTimeFromInt32, DateTime.Today);
    }
