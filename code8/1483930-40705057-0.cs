    public ViewB(ViewModelA viewModelA)
    {
        InitializeComponents();
        var viewModelB = DataContext as ViewModelB;
        viewModelB.MyViewModelA = viewModelA;
    }
