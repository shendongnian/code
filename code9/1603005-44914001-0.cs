    dialog.CancelEvent += (s, e) =>
                        {
                            webClient.CancelAsync();
                        };
    
                        try
                        {
                            bytes = await webClient.DownloadDataTaskAsync(url);
                        }
                        catch (WebException wex)
                        {
                            if (wex.Status == WebExceptionStatus.RequestCanceled)
                                return;
                            Toast.MakeText(mContext, wex.Message + "," + wex?.InnerException?.Message, ToastLength.Long).Show();
                            dialog.Progress = 0;
                            return;
                        }
                        catch (TaskCanceledException)
                        {
                            return;
                        }
                        catch (Exception a)
                        {
                            Toast.MakeText(mContext, a.Message + "," + a?.InnerException?.Message, ToastLength.Long).Show();
                            dialog.Progress = 0;
                            return;
                        }
