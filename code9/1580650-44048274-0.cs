    [TestMethod()]
    [ExpectedException(typeof(ArgumentNullException), "A null HttpContent was inappropriately allowed")]
    public void Test_HttpContent_Null_Throws_Exception()
    {
        MultipartFormDataMemoryStreamProvider provider = new MultipartFormDataMemoryStreamProvider();
        provider.GetStream(null, null);
    }
