    private void master_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (sender is StaffData)
        {
            DoSomething((StaffData)sender);
        }
        else if (sender is SomeOtherData)
        {
            DoSomething((SomeOtherData)sender);
        }
        ...
    }
    private void DoSomething(StaffData data)
    {
        ...
    }
    private void DoSomething(SomeOtherData data)
    {
        ...
    }
