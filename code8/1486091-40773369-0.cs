    private string _DispMemberPath;
    public string DispMemberPath
    { 
      get {return _DispMemberPath; }
      set { _DispMemberPath= value; RaiseNotifyPropertyChanged(); }
    }
    private void SetDepartmentAsPath()
    {
        this.DispMemberPath = "Department";
    }
