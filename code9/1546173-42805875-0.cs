    private string _stringBranchIds;
    public string StringBranchIds {
        get { return _stringBranchIds; }
        set {
            if(value != _stringBranchIds) {
                _stringBranchIds = value;
                _splitIds = null; // only if actually a change
            }
        }
    }
    private string _splitIds;
    internal string[] GetSplitIds() {
        return _splitIds ?? (_splitIds =
            (_stringBranchIds ?? "").Replace(" ", "").Split(','));
    }
