        async void Button_Clicked(object sender, EventArgs e)
        {
            //Plugin.Geolocator.Abstractions.Position position = new Plugin.Geolocator.Abstractions.Position();
            //if (!locationProvider.IsGpsAvailable())
            //{
            //    //...
            //}
            //else
            //{
            try
            {
                btnGetLocation.IsEnabled = false;
                settingsLayout.IsVisible = true;
                labelLatitude.Text = string.Empty;
                labelLongitude.Text = string.Empty;
                //var locator = CrossGeolocator.Current;
                //locator.DesiredAccuracy = 0.5;
                CancellationTokenSource cancellationTokenSoruce = new CancellationTokenSource();
                CancellationToken ct = cancellationTokenSoruce.Token;
                image1.Scale = 0;
                image2.Scale = 0;
                image3.Scale = 0;
                Task[] tasks = new Task[3];
                tasks[0] = Task.Run(async () =>
                {
                    while (!ct.IsCancellationRequested)
                    {
                        await image1.ScaleTo(1, 400, Easing.Linear);
                        await image1.ScaleTo(0, 400, Easing.Linear);
                        await image1.TranslateTo(image1.TranslationX, image1.TranslationY, 600, Easing.Linear);
                    }
                });
                tasks[1] = Task.Run(async () =>
                {
                    while (!ct.IsCancellationRequested)
                    {
                        await image2.TranslateTo(image2.TranslationX, image2.TranslationY, 200, Easing.Linear);
                        await image2.ScaleTo(1, 400, Easing.Linear);
                        await image2.ScaleTo(0, 400, Easing.Linear);
                        await image2.TranslateTo(image2.TranslationX, image2.TranslationY, 400, Easing.Linear);
                    }
                });
                tasks[2] = Task.Run(async () =>
                {
                    while (!ct.IsCancellationRequested)
                    {
                        await image3.TranslateTo(image3.TranslationX, image3.TranslationY, 400, Easing.Linear);
                        await image3.ScaleTo(1, 400, Easing.Linear);
                        await image3.ScaleTo(0, 400, Easing.Linear);
                        await image3.TranslateTo(image3.TranslationX, image3.TranslationY, 200, Easing.Linear);
                    }
                });
                //position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                await Task.Delay(10000); //simulated GetPositionAsync
                cancellationTokenSoruce.Cancel();
                await Task.WhenAll(tasks);
                //no need in CancelAnimations, it is done when you exited the Task
                //ViewExtensions.CancelAnimations(image1);
                //ViewExtensions.CancelAnimations(image2);
                //ViewExtensions.CancelAnimations(image3);
            }
            catch
            {
            }
            image1.Scale = 0;
            image2.Scale = 0;
            image3.Scale = 0;
            //labelLatitude.Text = position.Latitude.ToString();
            //labelLongitude.Text = position.Longitude.ToString();
            //settingsLayout.IsVisible = false;
            btnGetLocation.IsEnabled = true;
        }
        //}
