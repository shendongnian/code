    private bool _isNew = false;
    public ManageRecord()
    {
        _isNew = true;
    }
    public ManageRecord(Record record)
    {
        // Same as existing, _record = record probably.
    }
    
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (_isNew)
            SaveMethod();
        else
            UpdateMethod(record);
    }
