    static string GetClipboardText()
    {
        string result = string.Empty;
        Thread staThread = new Thread(x =>
        {
            try
            {
                result = Clipboard.GetText();
            }
            catch (Exception ex)
            {
                result = ex.Message;
            }
        });
        staThread.SetApartmentState(ApartmentState.STA);
        staThread.Start();
        staThread.Join();
        return result;
    }
