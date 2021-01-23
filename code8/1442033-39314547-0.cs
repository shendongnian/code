    public static readonly DependencyProperty MainContentProperty =
       DependencyProperty.Register( 
          "MainContent", 
          typeof( object ), 
          typeof( MyControl ), 
          new PropertyMetadata( default( object ) ) );
    
    public object MainContent
    {
        get { return ( object ) GetValue( MainContentProperty ); }
        set { SetValue( MainContentProperty, value ); }
    }
