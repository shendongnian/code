    public static class MessageBox
    {
        public static void Show(string text, string caption)
        {
            text += "AAA";
            caption += "BBB";
            System.Windows.MessageBox.Show(text, caption);
        }
    }
