    [TestMethod]
    public void DateTimeToOADate()
    {
        double oADate = DateTime.Today.ToOADate();
        DateTime dateTimeFromOAdate = DateTime.FromOADate(oADate);
        Assert.AreEqual(dateTimeFromOAdate, DateTime.Today);
    }
