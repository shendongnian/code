    protected override void OnClick(ActionEventArgs e)
    {
        switch(e.YourTypeValueName)
        {
            case sth1:
            {
                ActionDoSth1();
            }
            break;
            case sth1:
            {
                ActionDoSth2();
            }
            break;
            ...
            ...
        }
        base.OnClick(e);
    }
