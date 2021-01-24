    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        // your code
        
        ViewModel.PropertyChanged += MyViewModel_PropertyChanged;
    }
    private void MyViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if(e.PropertyName == nameof(ViewModel.InitializeTask) && ViewModel.InitializeTask != null)
        {
            ViewModel.InitializeTask.PropertyChanged += ViewModel_InitializeTask_PropertyChanged;
        }
    }
    private void ViewModel_InitializeTask_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if(e.PropertyName == nameof(ViewModel.InitializeTask.IsSuccessfullyCompleted))
            SupportActionBar.Title = ViewModel.MyObject.Name;
    }
