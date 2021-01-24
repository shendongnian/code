    private List<string> _autoCompleteList;
    public List<String> AutoCompleteList
    {
        get
        {
            if (_autoCompleteList == null)
                return ((DataGridViewAutoCompleteColumn)this.OwningColumn).AutoCompleteList;
            else
                return
                    _autoCompleteList;
        }
        set
        {
            _autoCompleteList = value;
        }
    }
