    private async void Load()
    {
        OpenFileDialog opnfldlg = new OpenFileDialog();
        opnfldlg.Multiselect = false;
        if (opnfldlg.ShowDialog() == true)
        {
            if (OnWork != null)
                OnWork(this, true);
            // This is the part who takes a time
            Task<ReadResult> readTask await Task.Factory.StartNew(() => ReadImage(opnfldlg.FileName));
            ReadResult result = readTask.Result;
            if (OnWork != null)
                OnWork(this, false);
        }
    }
