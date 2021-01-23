    private readonly bool _isNewEntity;
    public ManageRecord()
    {
        _isNewEntity = true;
        // Same as existing, _record = new Record() ?
    }
    public ManageRecord(Record record)
    {
        _isNewEntity = false;
        // Same as existing, _record = record ?
    }
    
    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (_isNewEntity)
            SaveMethod();
        else
            UpdateMethod(record);
    }
