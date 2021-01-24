        protected override async void OnAppearing ()
        {
            base.OnAppearing ();
            var scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                // Stop scanning
                scanPage.IsScanning = false;
                // Pop the page and show the result
                Device.BeginInvokeOnMainThread(() => {
                    Navigation.PopAsync();
                    DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
            };
            // Navigate to our scanner page
             await pushAsyncPage(scanPage); // Here is the error            
        }
