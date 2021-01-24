		Entry objScanner= new Entry();
						objScanner.Placeholder = "Barcode";
						objScanner.Keyboard = Keyboard.Numeric;
						objScanner.HorizontalOptions = LayoutOptions.StartAndExpand;
						objScanner.WidthRequest = Application.Current.MainPage.Width - 40;
						objScanner.SetBinding(Entry.TextProperty, "ElementValue", BindingMode.TwoWay);
						objScanner.BindingContext = control;
					
						layout.Children.Add(objScanner);
						
						objScanner.Focused +=  async (s, e) =>
						{
							var scanPage = new ZXingScannerPage();
							await Navigation.PushAsync(scanPage);
							scanPage.OnScanResult += (result) =>
								{
									// Stop scanning
									scanPage.IsScanning = false;
									// Pop the page and show the result
									Device.BeginInvokeOnMainThread(async () =>
								   {
									   await Navigation.PopAsync();
									   objScanner.Text = result.Text;
									  // await DisplayAlert("Scanned Barcode", result.Text, "OK");
								   });
								};
						};
