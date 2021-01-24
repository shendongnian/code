    private bool _browsing = false;
    private void UploadFileSelection_SelectionChanged()
    {
        if (_browsing)
        {
            return;
        }
        if (SelectedItem == ASD)
        {
            try
            {
                _browsing = true;
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog()
                {
                    DefaultExt = ".*",
                    Filter = "* Files (*.*)|*.*"
                };
                bool? result = dlg.ShowDialog();
                if (result == true)
                    AddItem(dlg.FileName);
            }
            finally
            {
                _browsing = false;
            }
        }
    }
