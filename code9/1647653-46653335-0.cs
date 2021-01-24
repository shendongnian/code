    private void dropfiles(object sender, DragEventArgs e)
    {
        string[] droppedFiles = null;
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
        {
            droppedFiles = e.Data.GetData(DataFormats.FileDrop, true) as string[];
        }
        if ((null == droppedFiles) || (!droppedFiles.Any())) { return; }
        var myVM = DataContext as MyViewModel;
        //   MyViewModel.DropFiles should be ObservableCollection<String>
        myVM.DropFiles.Clear();
        foreach (string s in droppedFiles)
        {
            myVM.DropFiles.Add(s);
        }
    }
