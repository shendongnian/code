    Task<string> GetMirrors(string url, string somethingelse )
    {
        // this will signal that the Task is completed
        // we want the parent to wait
        var tcs = new TaskCompletionSource<string>(TaskCreationOptions.AttachedToParent);
           
        WebBrowser tempbrowser = new WebBrowser();
        tempbrowser.ScriptErrorsSuppressed = true;
        this.Controls.Add(tempbrowser);
        tempbrowser.DocumentCompleted += (s, e) => {
            // LoadLinkIntoQueue call 
            // we have a result so signal to the CompletionSource that we're done
            tcs.SetResult(e.Url.ToString());
               
            this.Controls.Remove(tempbrowser);
        };
        tempbrowser.Navigate(url);
        // we return the Task from the completion source
        return tcs.Task ; 
    }
