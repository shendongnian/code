    [TestMethod]
    public async Task Create_LogReader_Big_Log()
    {
        llt(ERROR_LOG, (log, state) => {
            Assert.IsTrue(log != null); // never get here!
        });
        await Task.Delay(3000);
    }
