    [TestMethod]
    public void OutputTotalsTarget()
    {
        var subject = new RandomlyDistributesNumbersTotallingTarget();
        for (var x = 0; x < 10000; x++)
        {
            var output = subject.GetTheNumbers(5, 100);
            Assert.AreEqual(100, output.Sum());
        }
    }
