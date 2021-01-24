    MediaStreamSource.SampleRequested += async (MediaStreamSource sender, MediaStreamSourceSampleRequestedEventArgs args) =>
                {
                    var deferal = args.Request.GetDeferral();
                    try
                    {
                        var timestamp = DateTime.Now - startedAt;
    
                        var file = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFileAsync(@"Assets\grpPC1.jpg");
                        using (var stream = await file.OpenReadAsync())
                        {
                            args.Request.Sample = await MediaStreamSample.CreateFromStreamAsync(
                                stream.GetInputStreamAt(0), (uint)stream.Size, timestamp);
                        }
                        args.Request.Sample.Duration = TimeSpan.FromSeconds(5);
                    }
                    finally
                    {
                        deferal.Complete();
                    }
                };
