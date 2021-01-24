    mainView.AddView(subView);
    subView.AddView(someOtherView);
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
        someOtherView.AtTopOf(mainView, myPadding),
        someOtherView.AtLeftOf(mainView, myPadding),
        someOtherView.AtRightOf(mainView, myPadding),
        someOtherView.AtBottomOf(mainView, myPadding)
    });
