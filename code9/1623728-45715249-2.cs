    public async Task<bool> DisplayMessage(string titile, string content)
    {
        objDialog = new AlertDialog.Builder(this)
           .SetTitle(titile)
           .SetMessage(content)
           .SetCancelable(false)
           .Create();
        bool result = false;
        await Task.Run(() =>
        {
            var waitHandle = new AutoResetEvent(false);
            objDialog.SetButton((int)(DialogButtonType.Positive), "yes", (sender, e) =>
            {
                result = true;
                waitHandle.Set();
            });
            objDialog.SetButton((int)DialogButtonType.Negative, "no", (sender, e) =>
            {
                result = false;
                waitHandle.Set();
            });
            RunOnUiThread(() =>
            {
                objDialog.Show();
            });
            waitHandle.WaitOne();
        });
        objDialog.Dispose();
        return result;
    }
