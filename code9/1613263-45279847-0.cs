    public void DoSomethingAccordingToYear(DateTime testDate)
    {
        if(testDate.Year < 2010)
            DoSomething();
        else
            DoSomethingElse();
    }
