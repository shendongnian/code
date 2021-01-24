    private const int TestExceptionEventId = 21;
    
    [NonEvent]
    public void TestException(string operationType, Exception ex)
    {
        string shark = ex.ToString();
        TestException(operationType, shark);
    }
    [Event(TestExceptionEventId, Level = EventLevel.Error, Message = "{0} - {1}", Keywords = Keywords.Exception)]
    public void TestException(string operationType, string shark)
    {
        WriteEvent(TestExceptionEventId, operationType, shark);
    }
