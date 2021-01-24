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
								break; // Make your magic here
							case EnumAction.CompletePicture:
								break; // Make your magic here
							default:
								break; // Make your magic here
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
