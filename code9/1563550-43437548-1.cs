    DateTime lastWriteTime = DateTime.Now
    private void timer_tick(object sender, EventArgs e)
    {
        FileInfo f = new FileInfo("C:\\myFile.txt");
        if ( lastWriteTime == f.LastWriteTime) return;
        lastWriteTime = f.LastWriteTime;
        UpdateBindingList();
    }
    private void UpdateBindingList()
    {
        _bindingList.Clear();
        //then read the file and add items to _bindingList.
    }
