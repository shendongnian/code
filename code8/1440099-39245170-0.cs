    [TestMethod]
    public void DateTimeToInt64()
    {
       long ticks = DateTime.Today.Ticks;
    
       DateTime dateTimeFromTicks = new DateTime().AddTicks(ticks);
    
       Assert.AreEqual(dateTimeFromTicks, DateTime.Today);
    }
