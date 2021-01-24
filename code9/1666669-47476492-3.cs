    async void bttnDelivery_Clicked1(object sender, EventArgs e)
    {
        try
        {
			var taskResult = new TaskCompletionSource<EnumAction>();
			taskResult.ContinueWith(result => 
				{
					if(result.IsCompleted)
					{
						switch (result.Result)
						{
							case EnumAction.NextPicture:
								break; // Make you magic here
							case EnumAction.CompletePicture:
								break; // Make you magic here
							default:
								break; // Make you magic here
						}
					}
				});
            var testPopup = new PopupDemo(taskResult);
            await Navigation.PushPopupAsync(testPopup); 
        }
        catch (Exception ex)
        {
        }
    }
