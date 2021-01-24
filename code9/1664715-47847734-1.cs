    switch (MyAction)
    {
        case ClickButtonOne:
            // find the button, check if not null
            MyAction = CurrentAction.DoSomethingElse; // set a new action
            button.Click();
            break;
        case DoSomethingElse:
            // Do something
            MyAction = CurrentAction.ClickTheOtherButton; // set a new action
            break;
        case ClickTheOtherButton:
            // this is the last page, so lets stop here
            MyAction = CurrentAction.DoNothing; // specific action
            break;           
        default:
            Debug.Assert(false); break;
    }
