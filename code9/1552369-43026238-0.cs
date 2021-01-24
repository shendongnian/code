    private BindingList<string> presetLines;
    public YourForm()
    {
        var tempList = Enumerable.Repeat(string.Empty, 20).ToList();
        _presetLines = new BindingList(tempList);
        yourDataGridView.DataSource = _presetLines;
    }
