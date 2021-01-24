    protected override void OnPause()
    {
        ViewModel.OnMonkeySelected -= ViewModel_OnMonkeySelected;
        base.OnPause();
    }
    
    protected override void OnResume()
    {
        ViewModel.OnMonkeySelected += ViewModel_OnMonkeySelected;
        base.OnResume();
    }
    
    private void ViewModel_OnMonkeySelected(object sender, GenericWebViewViewModel.SelectedMonkeyEventArgs e)
    {
        Toast.MakeText(this, $"Selected Monkey {e.Monkey.Name }", ToastLength.Short)
            .Show();
    }
