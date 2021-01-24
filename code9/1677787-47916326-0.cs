    // Dependency Property
    public static readonly DependencyProperty DirectoryPathProperty = 
         DependencyProperty.Register( "DirectoryPath", typeof(string),
         typeof(DirectorySetter), new FrameworkPropertyMetadata(string.Empty));
     
    // .NET Property wrapper
    public string DirectoryPath
    {
        get { return (string)GetValue(DependencyProperty ); }
        set { SetValue(DependencyProperty , value); }
    }
