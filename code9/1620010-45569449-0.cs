    Windows.Storage.CachedFileManager.DeferUpdates(file);
                IRandomAccessStream stream = await file.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
                using (IOutputStream outputStream = stream.GetOutputStreamAt(0))
                {
                    await inkCanvas.InkPresenter.StrokeContainer.SaveAsync(outputStream);
                    await outputStream.FlushAsync();
                }
                stream.Dispose();
                Windows.Storage.Provider.FileUpdateStatus status =
                    await Windows.Storage.CachedFileManager.CompleteUpdatesAsync(file);
                if (status == Windows.Storage.Provider.FileUpdateStatus.Complete)
                {
                    // File saved
                }
                else
                {
                    // File NOT saved
                }
