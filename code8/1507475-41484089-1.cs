    private async void Load()
    {
        OpenFileDialog opnfldlg = new OpenFileDialog();
        opnfldlg.Multiselect = false;
        if (opnfldlg.ShowDialog() == true)
        {
            if (OnWork != null)
                OnWork(this, true);
            // This is the part who takes a time
            ReadResult result = await Task.Factory.StartNew(() => ReadImage(opnfldlg.FileName));
            if (OnWork != null)
                OnWork(this, false);
        }
    }
