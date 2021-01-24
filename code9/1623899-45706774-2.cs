    mainView.Add(subView);
    subView.Add(someOtherView);
    var myPadding = 12f;
    mainView.AddConstraints(new FluentLayout[]
    {
        subView.AtTopOf(mainView, myPadding),
        subView.AtLeftOf(mainView, myPadding),
        subView.AtRightOf(mainView, myPadding),
        subView.AtBottomOf(mainView, myPadding)
    });
    subView.AddConstraints(new FluentLayout[]
    {
        someOtherView.AtTopOf(subView, myPadding),
        someOtherView.AtLeftOf(subView, myPadding),
        someOtherView.AtRightOf(subView, myPadding),
        someOtherView.AtBottomOf(subView, myPadding)
    });
