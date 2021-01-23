    public static class Extension
    {
        public static async Task CloseAfterDelay(this Form form, int millisecondsDelay )
        {
            await Task.Delay( millisecondsDelay );
            form.Close();
        }
    }
