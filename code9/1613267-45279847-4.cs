    public void DoSomethingAccordingToYear(DateTime? testDate = null)
    {
        testDate = testDate ?? DateTime.Now;
        if (testDate.Year < 2010)
            DoSomething();
        else
            DoSomethingElse();
    }
