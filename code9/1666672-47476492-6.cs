    private async void btnClose_Clicked(object sender, EventArgs e)
	{
		Navigation.PopPopupAsync();
		task?.SetResult(EnumAction.NextPicture)
	}
		
	private async void btnComplete_Clicked(object sender, EventArgs e)
	{
		Navigation.PopPopupAsync();
		task?.SetResult(EnumAction.CompletePicture)
	}
		
	protected override void OnDisappearing()
    {
        base.OnDisappearing();
			
        if(task != null)
	        if(!task.Task.IsCanceled && !task.Task.IsFaulted && !task.Task.IsCompleted)
		        task.SetCanceled();
    }
