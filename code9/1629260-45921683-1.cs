    try
    {
        if (errMessage.Contains(EXCEPTIONCOMPARISONMESSAGE))
        {
            throw new MyEvilException();
        }
    }
    catch (Exception ex)
    {
        eventLog.WriteEntry("isAbleConvertToPDF: " + ex.Message, EventLogEntryType.Error);
    }
    private class MyEvilException : Exception
    {
        public override String Message 
        {
            get 
            {  
                return null;
            }
        }
    }
