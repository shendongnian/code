    <TextBox x:Name="txtFirstnameFilter" MinWidth="50" Text="{Binding FirstNameToFilterOn}" />
    <Label Content="Nazwisko" />
    <TextBox x:Name="txtLastnameFilter" MinWidth="50" Text="{Binding LastNameToFilterOn}" />
----------
    private string _f;
    public string FirstNameToFilterOn
    {
        get { return _f; }
        set { _f = value; Filter(); }
    }
    private string _l;
    public string LastNameToFilterOn
    {
        get { return _l; }
        set { _l = value; Filter(); }
    }
    public void Filter()
    {
        this.Candidates.Filter = item =>
        {
            Candidate candidate = item as Candidate;
            if (candidate == null)
                return false;
            return (string.IsNullOrEmpty(FirstNameToFilterOn) || string.IsNullOrEmpty(candidate.firstname) || candidate.firstname.Contains(FirstNameToFilterOn))
             && (string.IsNullOrEmpty(LastNameToFilterOn) || string.IsNullOrEmpty(candidate.lastname) || candidate.lastname.Contains(LastNameToFilterOn));
        };
        this.Candidates.Refresh();
    }
