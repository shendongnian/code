        private bool alreadyScanned;
                protected override async void OnAppearing()
                {
                    base.OnAppearing();
                    if(alreadyScanned)
                        return;
                    var scanPage = new ZXingScannerPage();
                scanPage.OnScanResult += (result) => {
                    // Stop scanning
                    scanPage.IsScanning = false;
        
                    // Pop the page and show the result
                    Device.BeginInvokeOnMainThread(() => {
                        Navigation.PopAsync();
                    alreadyScanned = true;
                        DisplayAlert("Scanned Barcode", result.Text, "OK");
                    });
                };
                    await Navigation.PushAsync(page);
                }
