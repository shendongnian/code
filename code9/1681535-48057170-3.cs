    public static void LogScreen<T>(T TArg)
        where T : BaseViewModel
    {
        var viewModel = TArg as BaseViewModel;
        var viewModel2 = TArg; //added this version
    }
