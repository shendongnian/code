    ReactiveList<IssueTypeSearchFilter> issueTypeFilterList
    public ReactiveList<IssueTypeSearchFilter> IssueTypeFilterList 
    { 
        get { return  issueTypeFilterList; }; 
        set { this.RaiseAndSetIfChanged(ref issueTypeFilterList, value); }; 
    }
