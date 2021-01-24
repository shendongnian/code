    [TestMethod]
    public void Create_LogReader_Big_Log() {
        // Use this event to wait until the asynchronous code has been executed 
        // before leaving the test method
        ManualResetEvent resetEvent = new ManualResetEvent(false);
        
        llt(ERROR_LOG, (log, state) => {
            Assert.IsTrue(log != null);
            
            // Signal that the test has reached the end
            resetEvent.Set();
        });
    
        // Wait for the event to be set
        resetEvent.WaitOne();
     
        // Additionally wait for a grace period to allow the other thread to fully terminate
        Thread.Sleep(500);
    }
