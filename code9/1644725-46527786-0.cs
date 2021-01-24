                if (result.Text.IsValidJson<DeviceSetup>())
                {
                    // Stop scanning
                    scanPage.IsScanning = false;
                    // Pop the page and show the result
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await _navigation.PopModalAsync(true);
                    });
                    // Here send a message
                    MessagingCenter.Send<MyPage, string>(this, "BarcodeRead", result.Text);
                    //barcodestring = result.Text;
                }
