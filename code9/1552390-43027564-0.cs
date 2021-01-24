    public static class MessageBoxHelper
    {
        const string _defaultCaption = "Message";
        const MessageBoxButtons _defaultButtons = MessageBoxButtons.OK;
        public static void Show(string message, MessageBoxIcon icon)
        {
            MessageBox.Show(message, _defaultCaption, _defaultButtons, icon);
        }
    }
