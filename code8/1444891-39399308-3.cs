    public void AssertTimeout()
    {
        DateTime newEndTime;
        newEndTime = endTime; 
        if (ProgramTimer.getTimespanInDebug()) {
            newEndTime = endTime.Subtract(ProgramTimer.getTimespanInDebug());
        }
        if (DateTime.UtcNow > newEndTime)
            throw new TimeoutException();
    }
