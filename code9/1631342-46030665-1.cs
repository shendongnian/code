    private MvxCommand<string> _subunitSelectedCommand;
    public ICommand MyCommand =>
         _subunitSelectedCommand =
                (_subunitSelectedCommand ?? new MvxCommand<string>(OnSubunitSelected));
    private void OnSubunitSelected(string name)
    {
        //Do your validated logic
    }
