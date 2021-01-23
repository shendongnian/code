    protected override void OnAppearing()
		{
			base.OnAppearing();
			ViewModel.RefreshScrollDown = () => {
				if (ViewModel.Messages.Count > 0) {
					Device.BeginInvokeOnMainThread (() => {
						
						ListViewMessages.ScrollTo (ViewModel.Messages [ViewModel.Messages.Count - 1], ScrollToPosition.End, true);
                    });
                }
			};
		}
