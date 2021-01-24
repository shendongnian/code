      public static string PickFolder()
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            string folder = string.Empty;
            switch (result)
            {
                case System.Windows.Forms.DialogResult.OK: return dialog.SelectedPath;
                case System.Windows.Forms.DialogResult.Cancel: return string.Empty;
                default: return string.Empty;
            }
        }
