    ViewModel1 vm;
    ...
    protected override void OnCreate(Bundle bundle)
    {
        base.OnCreate(bundle);
        ...
        vm = ViewModel as ViewModel1;
        ...
    }
    //what you want to do is refreshing the list on resume
    protected override void OnResume()
    {
        base.OnRefresh()
        vm.refresh();
        ... //other things you might want to do
    }
