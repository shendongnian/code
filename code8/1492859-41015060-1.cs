    public GroupedIssueTypeSearchFilter(int catID, string catTitle, List<IssueTypeSearchFilter> issueTypeList)
    {
        this.CategoryID = catID;
        this.CategoryTitle = catTitle;
        this.IssueTypeFilterList.Clear();
        this.IssueTypeFilterList.AddRange(issueTypeList);
    }
