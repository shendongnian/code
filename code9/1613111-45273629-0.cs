    public static class ExtensionClassForClosing
    {
        public static async Task CloseAfterXDelay(this Form form, int milliSecDelay )
        {
            await Task.Delay( milliSecDelay );
            form.Close();
        }
    }
