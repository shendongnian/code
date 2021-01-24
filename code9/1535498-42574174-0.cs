    static async Task DownloadFile(string url, string output, TimeSpan timeout) {            
        using (var wcl = new WebClient())
        {
            wcl.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;                                                
            var download = wcl.DownloadFileTaskAsync(url, output);
            // await two tasks - download and delay, whichever completes first
            await Task.WhenAny(Task.Delay(timeout), download);
            bool cancelled = false;
            // download is not completed yet, nor it is failed - cancel
            if (!download.IsCompleted && !download.IsFaulted) {
                wcl.CancelAsync();
                cancelled = true;
            }
            if (download.Exception != null) {
                // handle fault somehow
            }
            if (!download.IsCompleted) {
                // delete partially downloaded file (note - need to do with retry, might not work with a first try, because CancelAsync is not immediate)
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
            if (cancelled || download.IsFaulted) {
                // might want to throw exception here
            }
        }
    }
