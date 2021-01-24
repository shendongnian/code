    async void Button_Clicked(object sender, EventArgs e)
            {
                Plugin.Geolocator.Abstractions.Position position = new Plugin.Geolocator.Abstractions.Position();
    
                if(!locationProvider.IsGpsAvailable()){
                    //
                }
                else
                {
                    CancellationTokenSource cancellationTokenSoruce = new CancellationTokenSource();
                    CancellationToken ct = cancellationTokenSoruce.Token;
    
                    image1.Scale = 0;
                    image2.Scale = 0;
                    image3.Scale = 0;
    
                    labelLatitude.Text = string.Empty;
                    labelLongitude.Text = string.Empty;
    
                    Content = acquiringLocationLayoutHandler;
    
                    try
                    {
                        var locator = CrossGeolocator.Current;
                        locator.DesiredAccuracy = 0.5;
    
                        var t1 = Task.Run(async () =>
                        {
                            while(!ct.IsCancellationRequested)
                            {
                                await image1.ScaleTo(1, 400, Easing.Linear);
                                await image1.ScaleTo(0, 400, Easing.Linear);
                                await image1.TranslateTo(image1.TranslationX, image1.TranslationY, 600, Easing.Linear);
                                
                                if (ct.IsCancellationRequested)
                                {
                                    ViewExtensions.CancelAnimations(image1);
                                }
                            }
                        }, ct);
    
                        var t2 = Task.Run(async () =>
                        {
                            while (!ct.IsCancellationRequested)
                            {
                                await image2.TranslateTo(image2.TranslationX, image2.TranslationY, 200, Easing.Linear);
                                await image2.ScaleTo(1, 400, Easing.Linear);
                                await image2.ScaleTo(0, 400, Easing.Linear);
                                await image2.TranslateTo(image2.TranslationX, image2.TranslationY, 400, Easing.Linear);
    
                                if (ct.IsCancellationRequested)
                                {
                                    ViewExtensions.CancelAnimations(image2);
                                }
                            }
                        }, ct);
    
                        var t3 = Task.Run(async () =>
                        {
                            while (!ct.IsCancellationRequested)
                            {
                                await image3.TranslateTo(image3.TranslationX, image3.TranslationY, 400, Easing.Linear);
                                await image3.ScaleTo(1, 400, Easing.Linear);
                                await image3.ScaleTo(0, 400, Easing.Linear);
                                await image3.TranslateTo(image3.TranslationX, image3.TranslationY, 200, Easing.Linear);
    
                                if (ct.IsCancellationRequested)
                                {
                                    ViewExtensions.CancelAnimations(image3);
                                }
                            }
                        }, ct);
    
                        position = await locator.GetPositionAsync(timeoutMilliseconds: 10000);
                    }
                    catch(Exception ee)
                    {
                        Debug.WriteLine(ee.Message);
                    }
                    finally
                    {
                        cancellationTokenSoruce.Cancel();   
                    }
    
                    labelLatitude.Text = position.Latitude.ToString();
                    labelLongitude.Text = position.Longitude.ToString();
                    
                    Content = mainLayoutHandler;
                }
