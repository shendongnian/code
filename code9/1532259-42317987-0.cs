    public YourWpfWindow()
    {
        // ...
        this.DataContext = this;
    }
    private List<string> permissionList;
    public List<string> PermissionList
    {
        get { return permissionList; }
        set { permissionList = value; OnPropertyChanged("PermissionList"); }
    }
    private void fileSavePerms_Click(object sender, RoutedEventArgs e)
    {
        // You create a new instance of List<string>
        var newPermissionList = new List<string>();
        // your foreach statement that fills this newPermissionList
        // ...
        // At the end you simply replace the property value with this new list
        PermissionList = newPermissionList;
    }
