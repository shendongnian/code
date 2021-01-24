    static async Task DownloadFile(string url, string output, TimeSpan timeout) {            
        using (var wcl = new WebClient())
        {
            wcl.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;                                                
            var download = wcl.DownloadFileTaskAsync(url, output);
            // await two tasks - download and delay, whichever completes first
            await Task.WhenAny(Task.Delay(timeout), download);
            var exception = download.Exception; // need to observe exception, if any
            bool cancelled = !download.IsCompleted && exception == null;
            
            // download is not completed yet, nor it is failed - cancel
            if (cancelled) {
                wcl.CancelAsync();
            }
            if (cancelled || exception != null) {
                // delete partially downloaded file if any (note - need to do with retry, might not work with a first try, because CancelAsync is not immediate)
                int fails = 0;
                while (true) {
                    try {
                        File.Delete(output);
                        break;
                    }
                    catch {
                        fails++;
                        if (fails >= 10)
                            break;
                        await Task.Delay(1000);
                    }
                }
            }
            if (exception != null) {
                throw new Exception("Failed to download file", exception);
            }
            if (cancelled) {
                throw new Exception($"Failed to download file (timeout reached: {timeout})");
            }
        }
    }
