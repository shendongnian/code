		protected override void OnAppearing ()
		{
			base.OnAppearing ();
            // Enable receive barcode
			MessagingCenter.Subscribe<App, string> (this, "ScanBarcode", (sender, arg) => {
				
                 // In "arg" there is your barcode
			});
					
		}
		protected override void OnDisappearing ()
		{
			base.OnDisappearing ();
			// Disable receive barcode 
			MessagingCenter.Unsubscribe<App, string> (this, "ScanBarcode");
		}
