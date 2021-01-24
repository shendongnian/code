		protected override void OnAppearing ()
		{
			base.OnAppearing ();
            // Enable receive barcode
			MessagingCenter.Subscribe<App, string> (this, "ScanBarcode", (sender, arg) => {
				
                 // In "arg" there is your barcode
                try
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        DisplayAlert("BARCODE READ", arg, "OK");
                    });
                }
                catch(Exception ex){
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
			});
					
		}
		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			// Disable receive barcode 
			MessagingCenter.Unsubscribe<App, string> (this, "ScanBarcode");
		}
