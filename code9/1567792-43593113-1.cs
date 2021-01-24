    public event EventHandler ButtonClicked;
    public async void OnButtonClicked()
	{
		await Application.Current.MainPage.Navigation.PopAsync();
	}
