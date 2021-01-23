    class BadClassMock : BadClass
    {
        public BadClassMock()
        {
        }
        public bool someFlag;
        public void InitForTest()
        {
            someFlag = true;
        }
    }
